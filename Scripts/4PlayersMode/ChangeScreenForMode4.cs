using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreenForMode4 : MonoBehaviour
{
    [Header ("Game Object Properties")]
    public GameObject one;
    public GameObject two;
    public GameObject three;
    public GameObject battle;
    public GameObject stage;
    public GameObject rewardScreen;

    [Header("Scene ID Parameters")]
    public int modeID;
    public int menuID;

    [Header("Player Movement Controller")]
    public MovementController1 player1;
    public MovementController1 player2;
    public MovementController1 player3;
    public MovementController1 player4;

    private void Update()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        three.SetActive(true);
        yield return new WaitForSeconds(1f);
        three.SetActive(false);
        two.SetActive(true);
        yield return new WaitForSeconds(1f);
        two.SetActive(false);
        one.SetActive(true);
        yield return new WaitForSeconds(1f);
        one.SetActive(false);
        battle.SetActive(true);
        yield return new WaitForSeconds(1f);
        battle.SetActive(false);
        yield return new WaitForSeconds(1f);
        stage.SetActive(true);
    }

    public void RestartFromRewardScreen()
    {
        SceneManager.LoadScene(modeID);
    }
    
}
