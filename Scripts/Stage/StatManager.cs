using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StatManager : MonoBehaviour
{
    public TextMeshProUGUI text;

    public TextMeshProUGUI speedValue;

    public TextMeshProUGUI bombValue;

    public TextMeshProUGUI radiusValue;

    public void DisplayString(TextMeshProUGUI text, float n)
    {
        text.text = n.ToString();
    }

    
}
