using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PasswordTask : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform num1, num2, num3;
    public RectTransform numf1, numf2, numf3;

    public void Verify()
    {
        bool box1 = num1.position == numf1.position;
        bool box2 = num2.position == numf2.position;
        bool box3 = num3.position == numf3.position;

        Debug.Log(box1 && box2 && box3);
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
