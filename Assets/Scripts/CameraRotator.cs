using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    public float rotationSpeed = Mathf.PI * 0.25f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Constantyl rotates camera / pivot point
        transform.Rotate(Vector3.up, Time.deltaTime * rotationSpeed);
    }
}
