using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayBeforeStage : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string s = ("Welcome to Multiplayer mode, you will play against other players to win the war, you must break the stone and move around the map to kill other players. The players who remains last will win");
    public GameObject dialogueBox;
    public GameObject gotoButton;
    public GameObject stage;
    public GameObject dialogueScreen;
    public GameObject loadingScreen;

    public AudioClip Count;

    private bool isWritten = false;

    public void DisplayText()
    {
        if (!isWritten)
        {
            dialogueBox.SetActive(true);
            gotoButton.SetActive(true);
            StartCoroutine(AddLetter(s));
        }
        isWritten = true;
    }

    IEnumerator AddLetter(string s)
    {
        text.text = "";
        foreach (char letter in s.ToCharArray())
        {
             text.text += letter;
             yield return new WaitForSeconds(0.05f);
        }
    }

    public void LoadingStage()
    {
        dialogueScreen.SetActive(false);
        loadingScreen.SetActive(true);
    }
}
