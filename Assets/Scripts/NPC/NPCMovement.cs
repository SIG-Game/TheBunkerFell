using System;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    private float speed = 0;
    private GameObject target;
    private NPCState state;  // idle state
    private Vector3 movementDirection;  // moving the direction the player is facing

    [SerializeField] private CharacterController controller;
    [SerializeField] private float chaseDistanceSquared;
    [SerializeField] private float stopDistanceSquared;
    [SerializeField] private NPCSensor NPCSensor;

    private void OnEnable()
    {
        NPCSensor.OnPlayerEnterSensor += OnTargetSensed;
        NPCSensor.OnPlayerExitSensor += OnTargetEscape;
    }

    public void OnTargetSensed(object sender, GameObject newTarget)
    {
        target = newTarget;
        state = NPCState.Following;
        speed = newTarget.GetComponent<PlayerMovement>().speed;
        var targetNPCManager = target.GetComponent<PlayerNPCCommands>();

        targetNPCManager?.AddNPC(this);
    }

    public void OnTargetEscape(object sender, EventArgs e)
    {
        var targetNPCManager = target.GetComponent<PlayerNPCCommands>();

        targetNPCManager?.RemoveNPC(this);

        target = null;
    }

    private void LateUpdate()
    {
        //
        // check if target has been found and needs chasing
        //
        if (target != null && state < NPCState.Charging)  // there's a target to follow and the NPC's not performing a command
        {
            Vector3 directionToPlayer = target.transform.position - transform.position;
            directionToPlayer.y = 0;  // ignore y-position

            // get distance between player and NPC
            float distanceSquared = directionToPlayer.sqrMagnitude;

            // player is too far, follow them!
            if (state == 0 && distanceSquared > chaseDistanceSquared)
            {
                state = NPCState.Following;  // chasing state
            }

            if (state == NPCState.Following)
            {
                Vector3 movementDirection = directionToPlayer.normalized; ;  // get direction only
                controller.Move(movementDirection * speed * Time.deltaTime);

                // player's too close, stop!
                if (distanceSquared < stopDistanceSquared)
                {
                    state = 0;
                }
            }
        }

        if (state == NPCState.Charging)  // following player's order of running forward
        {
            controller.Move(movementDirection * speed * Time.deltaTime);
        }
    }

    public NPCState GetState() => state;

    public void DirectNPC()
    {
        state = NPCState.Charging;
        movementDirection = target.transform.forward;  // move forward player's direction
    }

    public void CallNPC()
    {
        state = NPCState.Idling;
    }
}
