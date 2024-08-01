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
    private bool chasing = false;
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
        speed = newTarget.GetComponent<PlayerMovement>().speed;
    }

    public void OnTargetEscape(object sender, EventArgs e)
    {
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
        if (target != null)  // there's a target to follow
        {
            Vector3 direction = target.transform.position - transform.position;
            direction.y = 0;  // ignore y-position

            // get distance between player and NPC
            float distanceSquared = direction.sqrMagnitude;

            // player is too far, follow them!
            if (!chasing && distanceSquared > chaseDistanceSquared)
            {
                chasing = true;
            }

            if (chasing)
            {
                direction.Normalize();  // get direction only
                controller.Move(direction * speed * Time.deltaTime);

                // player's too close, stop!
                if (distanceSquared < stopDistanceSquared)
                {
                    chasing = false;
                }
            }
        }
    }
}
