using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    // gravity and ground values
    private float speed = 0;
    public float gravity = -9.81f;
    public CharacterController controller;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;

    // target chasing values
    private GameObject target;
    private int state = 0;  // idle state
    private Vector3 movementDirection;  // moving the direction the player is facing
    [SerializeField] float chaseDistanceSquared = 4;
    [SerializeField] float stopDistanceSquared = 2;
    [SerializeField] NPCSensor NPCSensor;

    private void OnEnable()
    {
        NPCSensor.OnPlayerEnterSensor += OnTargetSensed;
        NPCSensor.OnPlayerExitSensor += OnTargetEscape;
    }

    public void OnTargetSensed(object sender, GameObject newTarget)
    {
        target = newTarget;
        state = 1;
        speed = newTarget.GetComponent<PlayerMovement>().speed;
        var targetNPCManager = target.GetComponent<PlayerNPCCommands>();

        if (targetNPCManager != null)
        {
            targetNPCManager.AddNPC(this);
        }
    }

    public void OnTargetEscape(object sender, EventArgs e)
    {
        var targetNPCManager = target.GetComponent<PlayerNPCCommands>();

        if (targetNPCManager != null)
        {
            targetNPCManager.RemoveNPC(this);
        }

        target = null;
    }

    private void LateUpdate()
    {
        //
        // check for ground below and apply gravity to NPC
        //
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        //
        // check if target has been found and needs chasing
        //
        if (target != null && state < 2)  // there's a target to follow and the NPC's not performing a command
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.y = 0;  // ignore y-position

            // get distance between player and NPC
            float distanceSquared = direction.sqrMagnitude;

            // player is too far, follow them!
            if (state == 0 && distanceSquared > chaseDistanceSquared)
            {
                state = 1;  // chasing state
            }

            if (state == 1)
            {
                direction.Normalize();  // get direction only
                controller.Move(direction * speed * Time.deltaTime);

                // player's too close, stop!
                if (distanceSquared < stopDistanceSquared)
                {
                    state = 0;
                }
            }
        }

        if (state == 2)  // following player's order of running forward
        {
            controller.Move(movementDirection * speed * Time.deltaTime);
        }
    }

    public int GetState()
    {
        return state;
    }

    public void DirectNPC()
    {
        state = 2;
        movementDirection = target.transform.forward;  // move forward player's direction
    }

    public void CallNPC()
    {
        state = 1;
    }

    public void SetState(int _state)
    {
        state = _state;

        if (state == 2)
        {
            movementDirection = target.transform.forward;
        }
    }
}
