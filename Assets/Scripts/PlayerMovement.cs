using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Different speeds we can modify
    public float speed = 20f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public CharacterController controller;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    private Vector3 velocity;
    private bool isGrounded;

    public Tasks tasks;
    private int currenTask = -1;
    public int taskDistanceLimit = 10;

    // Start is called before the first frame update
    void Start()
    { }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Gets input from keys
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //Move object
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (currenTask != -1)
        {
            if (tasks.GetDistance(GetComponent<Transform>().position, currenTask) >= taskDistanceLimit)
            {
                tasks.HideTask(currenTask);
                currenTask = -1;
            }
        }
    }

    //Detects collision on Player
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Task obj = hit.gameObject.GetComponent<Task>();
        if (obj != null && !obj.getDone())
        {
            currenTask = obj.taskNumber;
            //Show specific task for it
            tasks.ShowTask(currenTask);
        }
    }
}
