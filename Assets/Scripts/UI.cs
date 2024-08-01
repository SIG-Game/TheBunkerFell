using System.Collections;
using System.Collections.Generic;
using Internal;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    int hearts = 0;
    int helpers = 0;

    public TMP_Text heart_text;
    public TMP_Text helper_text;

    // Start is called before the first frame update
    void Start()
    {
        heart_text.SetText(hearts.ToString());
        helper_text.SetText(helpers.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void incrementHearts()
    {
        hearts++;
        heart_text.SetText(hearts.ToString());
    }

    public void incrementHelpers()
    {
        helpers++;
        helper_text.SetText(helpers.ToString());
    }
}
