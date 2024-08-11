using System.Collections;
using System.Collections.Generic;
using UnityEngine.Internal;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{

    public TMP_Text heart_text;
    public TMP_Text helper_text;

    private int _hearts;
    private int _helpers;

    public int Hearts
    {
        get
        {
            return _hearts;
        }
        set
        {
            _hearts = value;
            heart_text.SetText(_hearts.ToString());
        }
    }

    public int Helpers
    {
        get
        {
            return _helpers;
        }
        set
        {
            _helpers = value;
            helper_text.SetText(_helpers.ToString());
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Hearts = 0;
        Helpers = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Hearts++;
        }
        

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Helpers++;
        }
    }
}
