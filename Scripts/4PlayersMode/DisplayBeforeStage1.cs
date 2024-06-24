using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayBeforeStage1 : MonoBehaviour
{
    public string Introduction = "Welcome to 4 players mode! Press Continue to see the next guide!";

    public string NextGuide = "Here are guide about the control of 4 characters including how to move and place the bomb! Press Continue to see the guide!";

    public TextMeshProUGUI text;

    private bool isWritten = false;
    private bool isWritten1 = false;

    public GameObject DisplayItem;
    public GameObject Continue1;
    public GameObject Continue2;
    public GameObject ManageCharacter;
    public GameObject DialogueScreen;

    [Header("Sound Parameters")]
    public AudioClip TextRunningSound;

    IEnumerator AddLetter(string s)
    {
        text.text = "";
        SoundManager.instance.PlaySound(TextRunningSound);
        foreach (char letter in s.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void DisplayText()
    {
        if (!isWritten)
        {
            DisplayItem.SetActive(true);
            StartCoroutine(AddLetter(Introduction));
        }
        isWritten = true;
    }

    public void DisplayText1()
    {
        if(!isWritten1)
        {
            Continue1.SetActive(false);
            Continue2.SetActive(true);
            StartCoroutine(AddLetter(NextGuide));
        }
        isWritten1 = true;
    }

    public void ChangeToGuide()
    {
        DialogueScreen.SetActive(false);
        ManageCharacter.SetActive(true);
    }

    
}
