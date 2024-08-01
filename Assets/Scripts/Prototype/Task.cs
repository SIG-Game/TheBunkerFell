using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{

    public int taskNumber;
    private bool isDone = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setFinished()
    {
        isDone = true;
    }

    public bool getDone()
    {
        return isDone;
    }
}
