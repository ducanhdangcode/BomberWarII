using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour
{
    public GameObject Publisher;
    public GameObject Studio;
    public GameObject SliderContainer;
    public Slider slider;

    public int sceneID;

    public AudioClip PublishSound;

    private void LoadToMenu()
    {
        SceneManager.LoadScene(sceneID);
    }
    IEnumerator Display()
    {
        Publisher.SetActive(true);
        SoundManager.instance.PlaySound(PublishSound);
        yield return new WaitForSeconds(1.5f);
        Studio.SetActive(true);
        yield return null;
    }

    IEnumerator ProcessLoad()
    {
        yield return new WaitForSeconds(1.5f);
        StartCoroutine(Display());
        yield return new WaitForSeconds(2f);

        SliderContainer.SetActive(true);
        yield return new WaitForSeconds(1f);
        while(slider.value <1)
        {
            slider.value += 0.005f;
            yield return new WaitForSeconds(2f);
        }
        if(slider.value == 1)
        {
            LoadToMenu();
        }
    }

    private void Update()
    {
        StartCoroutine(ProcessLoad());
    }
}
