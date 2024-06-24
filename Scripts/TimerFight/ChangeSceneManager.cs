using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    [Header("Scene Parameters")]
    public int StageSceneID;
    public int MenuID;

    public void Restart()
    {
        SceneManager.LoadScene(StageSceneID);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(MenuID);
    }
}
