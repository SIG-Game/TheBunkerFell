using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Tasks tasks;
    [SerializeField] private float speed;
    [SerializeField] private int taskDistanceLimit;

    private CharacterController characterController;
    private int currentTask = -1;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (currentTask != -1)
        {
            if (tasks.GetDistance(GetComponent<Transform>().position, currentTask) >= taskDistanceLimit)
            {
                tasks.HideTask(currentTask);
                currentTask = -1;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

        if (input.sqrMagnitude > 1f)
        {
            input.Normalize();
        }

        characterController.Move(speed * input);
    }

    //Detects collision on Player
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Task obj = hit.gameObject.GetComponent<Task>();
        if (obj != null && !obj.getDone())
        {
            currentTask = obj.taskNumber;
            //Show specific task for it
            tasks.ShowTask(currentTask);
        }
    }
}
