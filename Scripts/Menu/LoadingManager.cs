using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingManager : MonoBehaviour
{
    public GameObject optionMenu;
    public GameObject guideMenu;
    public GameObject dialogueScreen;
    public void LoadToDialogueBox()
    {
        optionMenu.SetActive(false);
        dialogueScreen.SetActive(true);
    }

    public void LoadToGuide()
    {
        dialogueScreen.SetActive(false);
        optionMenu.SetActive(true);
    }
}
