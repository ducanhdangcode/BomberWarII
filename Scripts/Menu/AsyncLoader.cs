using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class AsyncLoader : MonoBehaviour
{
    [Header("Game Object Parameters")]
    public GameObject dialougeScreen;
    public GameObject loadingScreen;
    public GameObject stageScreen;

    [Header("Slider Parameters")]
    public Slider loadingSlider;

    [Header("Scene Parameters")]
    public int StageID;

    private int rand;
    private void Start()
    {
        rand = Random.Range(0, 4);
    }

    public void LoadLevel()
    {
        dialougeScreen.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        while(loadingSlider.value <1)
        {
            loadingSlider.value += 0.1f;
            yield return new WaitForSeconds(0.5f);
        }

        if(loadingSlider.value==1)
        {
            loadingScreen.SetActive(false);
            stageScreen.SetActive(true);
        }
    }

    IEnumerator LoadScene2()
    {
        while (loadingSlider.value < 1)
        {
            loadingSlider.value += 0.1f;
            yield return new WaitForSeconds(0.5f);
        }

        if (loadingSlider.value == 1)
        {
            SceneManager.LoadScene(StageID);
        }
    }

    public void LoadToNextScene()
    {
        dialougeScreen.SetActive(false);
        loadingScreen.SetActive(true);
        StartCoroutine(LoadScene2());
    }
    
}
