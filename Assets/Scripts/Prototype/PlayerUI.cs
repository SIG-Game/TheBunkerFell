using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text text;
    private int currentTasks = 0;
    private int totalTasks = 4;

    // Start is called before the first frame update
    void Start()
    {
        text.SetText("Tasks: " + currentTasks.ToString() + "/" + totalTasks.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateTasks()
    {
        currentTasks++;
        Start();
    }
}
