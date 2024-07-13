using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverseerCameraLook : MonoBehaviour
{
    private float rotationX;
    private float rotationY;

    private float mouseSensitivity = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * -1 * mouseSensitivity;
        
        rotationY += mouseX;
        rotationX += mouseY;
        
        rotationX = Mathf.Clamp(rotationX, 0f, 90f);
        
        transform.localEulerAngles = new Vector3(rotationX,rotationY,0);
    }   
}
