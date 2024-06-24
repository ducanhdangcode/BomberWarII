using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public int sceneId;
    public void loadToNextScene()
    {
        SceneManager.LoadScene(sceneId);
    }
}
