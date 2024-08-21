using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tasks : MonoBehaviour
{

    public GameObject task1;
    public GameObject task2;
    public GameObject task3;
    public GameObject task4;

    private GameObject[] tasks;

    public GameObject taskUI1;
    public GameObject taskUI2;
    public GameObject taskUI3;
    public GameObject taskUI4;

    private Dictionary<GameObject, GameObject> myDictionary = new Dictionary<GameObject, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        // Initialize array
        tasks = new GameObject[4];
        tasks[0] = task1;
        tasks[1] = task2;
        tasks[2] = task3;
        tasks[3] = task4;

        myDictionary[task1] = taskUI1;
        myDictionary[task2] = taskUI2;
        myDictionary[task3] = taskUI3;
        myDictionary[task4] = taskUI4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetDistance(Vector3 playerPos, int num)
    {
        Vector3 taskPos = tasks[num].GetComponent<Transform>().position;
        return (int)Vector3.Distance(playerPos, taskPos);
    }

    public void ShowTask(int num)
    {
        myDictionary[tasks[num]].SetActive(true);
    }

    public void HideTask(int num)
    {
        myDictionary[tasks[num]].SetActive(false);
    }

    public GameObject getTask(int num)
    {
        return tasks[num];
    }
}
