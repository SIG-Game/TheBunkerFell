using System.Collections;
using System.Collections.Generic;
using UnityEngine.Internal;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private const int MAX_HEARTS = 5;
    private const int MAX_HELPERS = 6;

    [SerializeField] private List<Sprite> heartPics;
    [SerializeField] private Image healthBar;
    [SerializeField] private TMP_Text helperText;

    private void Start()
    {
        SetHelperText(0);
    }

    public void SetHealthBar(int value)
    {
        //Constraints for value
        if (value < 0) { value = 0; } else if (value > MAX_HEARTS) { value = MAX_HEARTS; }

        healthBar.sprite = heartPics[value];
    }

    public void SetHelperText(int value)
    {
        //Constraints for value
        if (value < 0) { value = 0; } else if (value > MAX_HELPERS) { value = MAX_HELPERS; }

        helperText.text = value.ToString();
    }
}
