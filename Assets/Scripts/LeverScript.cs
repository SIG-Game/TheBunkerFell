using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverScript : MonoBehaviour
{
    public RectTransform leverPosition, expectedPosition;
    private bool taskDone = false;

    public bool Verify()
    {
        return leverPosition.position == expectedPosition.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Verify() && !taskDone)
        {
            taskDone = true;
            Debug.Log("Task done");
        }
    }
}
