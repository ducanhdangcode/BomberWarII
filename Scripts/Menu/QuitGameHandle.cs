using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitGameHandle : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
    }

    public void Update()
    {
        quitGame();
    }
}
