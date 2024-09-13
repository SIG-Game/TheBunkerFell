using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Task1 : Task
{
    public GameObject self;
    public TextMeshProUGUI heading;
    public TMP_InputField userInput;
    public PlayerUI tasksCounter;

    private string headingText = "Enter PIN: ";
    private int randomPin;
    // Start is called before the first frame update
    void Start()
    {
        randomPin = Random.Range(0, 9999);
        //Sets text of header
        heading.SetText(headingText + randomPin.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Gets input from textinput and checks if is valid
    public void InputSubmit()
    {
        if (int.Parse(userInput.text) == randomPin)
        {
            //If valid, increment tasks
            tasksCounter.UpdateTasks();
            setFinished();
            self.SetActive(false);
        }
    }
}
