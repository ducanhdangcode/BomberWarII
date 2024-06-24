using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DigitalClockManagement : MonoBehaviour
{
    [Header("Time Parameters")]
    public float TimeLeft;
    public TextMeshProUGUI TimeText;

    private ChangeToRewardScreenManagement changeToRewardScreenManagement;

    private bool isCountdown = false;

    private void Start()
    {
        isCountdown = true;
        changeToRewardScreenManagement = GetComponent<ChangeToRewardScreenManagement>();
    }

    private void Update()
    {
        if(isCountdown)
        {
            if(TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                CountDown(TimeLeft);
            } else
            {
                TimeLeft = 0;
                isCountdown= false;
                changeToRewardScreenManagement.ManageWin();
            }
        }
    }

    private void CountDown(float TotalTime)
    {
        ++TotalTime;
        float minutes = Mathf.FloorToInt(TotalTime / 60);
        float seconds = Mathf.FloorToInt(TotalTime % 60);
        TimeText.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void AddTime()
    {
        TimeLeft += 60;
    }
}
