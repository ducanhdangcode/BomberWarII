using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DisplayGuide : MonoBehaviour
{
    [Header("String Parameters")]
    public string introduction = "Welcome to Timer Fight mode! Press continue to see the next guide!";
    public string overview = "In the Timer Fight mode, 2 players compete each other in a limited time. After that time, who has the higher score will win! Press Continue to see the controll and item guide!";

    [Header("Text Parameters")]
    public TextMeshProUGUI IntroductionText;

    [Header("Game Object Parameters")]
    public GameObject Continue1;
    public GameObject Continue2;
    public GameObject GuideScreen;
    public GameObject DialougeScreen;
    public GameObject DialougeBox;

    [Header("Scene Parameters")]
    public int ChooseModeSceneID;
    public int TimerFightSceneID;

    [Header("Sound Parameters")]
    public AudioClip TextRunningSound;

    private bool isWritten = false;
    private bool isFinished = false;
    private bool isWritten1 = false;

    IEnumerator AddLetter(string s)
    {
        IntroductionText.text = "";
        SoundManager.instance.PlaySound(TextRunningSound);
        foreach(char letter in s.ToCharArray())
        {
            IntroductionText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
        isFinished = true;
    }

    public void DisplayIntroduction()
    {
        if(isWritten == false)
        {
            DialougeBox.SetActive(true);
            StartCoroutine(AddLetter(introduction));
        }
        isWritten = true;
        if(isWritten == true)
        {
            DisplayContinue1();
        }
    }

    public void DisplayOverview()
    {
        if (isFinished == true)
        {
            if (isWritten1 == false)
            {
                if (isFinished == true)
                {
                    StartCoroutine(AddLetter(overview));
                }
            }
            isWritten1 = true;
            if (isWritten1 == true)
            {
                DisplayContinue2();
            }
        }
    }

    private void DisplayContinue1()
    {
        Continue1.SetActive(true);
    }

    private void DisplayContinue2()
    {
        Continue2.SetActive(true);
    }

    public void DisplayGuideScreen()
    {
        DialougeScreen.SetActive(false);
        GuideScreen.SetActive(true);
    }

    public void BackToChooseMode()
    {
        SceneManager.LoadScene(ChooseModeSceneID);
    }

    public void GoToTimerFight()
    {
        SceneManager.LoadScene(TimerFightSceneID);
    }
}
