using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FromStageBackToMenu : MonoBehaviour
{
    public void MoveToMenu(int sceneID)
    {
        SceneManager.LoadScene(sceneID);
    }
}
