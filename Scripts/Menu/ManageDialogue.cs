using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManageDialogue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TextMeshProUGUI text1;
    public string s = "Hello!";
    public string str = "Here are guide board providing information about the war. Press Continue to see the board!";
    public GameObject dialogueBox;
    public GameObject continueButton;
    public GameObject newContinueButton;
    public GameObject dialogueScreen;
    public GameObject guideBoardScreen;
    public GameObject optionMenu;

    private bool isWritten = false;
    private bool isWritten1 = false;


    public void HasConversation()
    {
        if (!isWritten)
        {
            text.text = "";
            dialogueBox.SetActive(true);
            continueButton.SetActive(true);
            StartCoroutine(AddLetter(s));
        }
        isWritten = true;
    }

    public void ShowGuideBoardText()
    {
        if (!isWritten1)
        {
            text.text = "";
            StartCoroutine(AddLetter(str));
        }
        isWritten1 = true;
    }

    public void changeContinueButton()
    {
        continueButton.SetActive(false);
        newContinueButton.SetActive(true);
    }

    IEnumerator AddLetter(string s)
    {
        foreach(char letter in s.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(0.08f);
        }
    }

    public void ShowGuideBoard()
    {
        dialogueScreen.SetActive(false);
        guideBoardScreen.SetActive(true);
    }

    public void MoveToOptionScreen()
    {
        dialogueScreen.SetActive(false);
        optionMenu.SetActive(true);
    }

    public void MoveToOptionMenu1()
    {
        guideBoardScreen.SetActive(false);
        optionMenu.SetActive(true);
    }
}
