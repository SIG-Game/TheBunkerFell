using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    public GameObject camera4;

    private GameObject[] cameras = {}; 

    public int currentCamera = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Initialize array
        cameras = new GameObject[4];
        cameras[0] = camera1;
        cameras[1] = camera2;
        cameras[2] = camera3;
        cameras[3] = camera4;

        SetCamera();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentCamera++;
            if (currentCamera >= cameras.Length)
            {
                currentCamera = 0;
            }
            SetCamera();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentCamera--;
            if (currentCamera < 0)
            {
                currentCamera = cameras.Length - 1;
            }
            SetCamera();
        }
    }

    void SetCamera()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            if (i == currentCamera)
            {
                cameras[i].SetActive(true);
                continue;
            }
            cameras[i].SetActive(false);
        }
    }
}
