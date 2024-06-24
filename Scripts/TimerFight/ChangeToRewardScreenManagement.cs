using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeToRewardScreenManagement : MonoBehaviour
{
    [Header("Game Object Parameters")]
    public GameObject Stage;
    public GameObject RewardScreenForPlayer1;
    public GameObject RewardScreenForPlayer2;

    [Header("Bomb Controller Parameters")]
    public BombController2 Player1;
    public BombController2 Player2;

    [Header("Movement Controller Parameters")]
    public MovementController2 Player1Movement;
    public MovementController2 Player2Movement;

    [Header("Text Parameters For Player1 Win")]
    public TextMeshProUGUI Player1Score;
    public TextMeshProUGUI Player2Score;
    public TextMeshProUGUI Player1Speed;
    public TextMeshProUGUI Player2Speed;
    public TextMeshProUGUI Player1Radius;
    public TextMeshProUGUI Player2Radius;
    public TextMeshProUGUI Player1BombAmount;
    public TextMeshProUGUI Player2BombAmount;

    [Header("Text Parameters For Player2 Win")]
    public TextMeshProUGUI Player1Score2;
    public TextMeshProUGUI Player2Score2;
    public TextMeshProUGUI Player1Speed2;
    public TextMeshProUGUI Player2Speed2;
    public TextMeshProUGUI Player1Radius2;
    public TextMeshProUGUI Player2Radius2;
    public TextMeshProUGUI Player1BombAmount2;
    public TextMeshProUGUI Player2BombAmount2;

    public void Player1Win()
    {
        Stage.SetActive(false);
        RewardScreenForPlayer1.SetActive(true);
    }

    public void Player2Win()
    {
        Stage.SetActive(false);
        RewardScreenForPlayer2.SetActive(true);
    }

    public void ManageWin()
    {
        int score1 = Player1.GetScore();
        int score2 = Player2.GetScore();
        if(score1 > score2)
        {
            SetUpStatistic1();
            Player1Win();
        } else
        {
            SetUpStatistic2();
            Player2Win();
        }
    }

    public void SetUpStatistic1()
    {
        Player1Score.text = Player1.GetScore().ToString();
        Player2Score.text = Player2.GetScore().ToString();
        Player1Speed.text = Player1Movement.speed.ToString();
        Player2Speed.text = Player2Movement.speed.ToString();
        Player1Radius.text = Player1.explosionRadius.ToString();
        Player2Radius.text = Player2.explosionRadius.ToString();
        Player1BombAmount.text = Player1.bombAmount.ToString();
        Player2BombAmount.text = Player2.bombAmount.ToString();
    }

    public void SetUpStatistic2()
    {
        Player1Score2.text = Player1.GetScore().ToString();
        Player2Score2.text = Player2.GetScore().ToString();
        Player1Speed2.text = Player1Movement.speed.ToString();
        Player2Speed2.text = Player2Movement.speed.ToString();
        Player1Radius2.text = Player1.explosionRadius.ToString();
        Player2Radius2.text = Player2.explosionRadius.ToString();
        Player1BombAmount2.text = Player1.bombAmount.ToString();
        Player2BombAmount2.text = Player2.bombAmount.ToString();
    }
}
