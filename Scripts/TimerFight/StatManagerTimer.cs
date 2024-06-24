using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatManagerTimer : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public void DisplayFloat(float value)
    {
        text.text = value.ToString();
    }

    public void DisplayInteger(int value)
    {
        text.text = value.ToString();
    } 
}
