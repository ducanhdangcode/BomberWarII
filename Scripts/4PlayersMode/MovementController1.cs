using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class MovementController1 : MonoBehaviour
{
    public new Rigidbody2D rb { private set; get; }
    private Vector2 direction = Vector2.down;

    [Header ("Movement Parameter")]
    public float speed = 5f;

    [Header ("Input Movement")]
    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode inputLeft = KeyCode.A;

    [Header("Animated Sprite Renderer")]
    public AnimatedSpriteRenderer1 spriteRendererDown;
    public AnimatedSpriteRenderer1 spriteRendererUp;
    public AnimatedSpriteRenderer1 spriteRendererRight;
    public AnimatedSpriteRenderer1 spriteRendererLeft;
    public AnimatedSpriteRenderer1 spriteRendererDeath;
    private AnimatedSpriteRenderer1 activeSpriteRenderer;

    private bool isDeath = false;

    private StatManager statManager;

    [Header("Score Attribute")]
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;
    public TextMeshProUGUI text3;

    [Header("Layer Name Attribute")]
    public string Mask = "Explosion";
    public string Mask2 = "Explosion2";
    public string Mask3 = "Explosion3";
    public string Mask4 = "Explosion4";


    private int score1 = 0;
    private int score2 = 0;
    private int score3 = 0;

    private bool isOver = false;

    [Header("GameObject Parameters")]
    public GameObject RewardScreen;
    public GameObject Stage;

    [Header("Sprite Parameters")]
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;
    public Sprite yourSprite;
    public ManageSprite manageSprite;

    [Header("Image Parameters")]
    public Image winnerImage;
    public Image secondImage;
    public Image thirdImage;
    public Image fourthImage;

    [Header("Text Parameters")]
    public TextMeshProUGUI yourScore;
    private int[] playerScore;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void Start()
    {
        statManager = GetComponent<StatManager>();
        playerScore = new int[4];
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer1 spriteRenderer)
    {
        direction = newDirection;

        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;

        activeSpriteRenderer = spriteRenderer;
        
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void Update()
    {
        if(Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteRendererUp);
        } else if(Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteRendererDown);
        } else if( Input.GetKey(inputRight)) {
            SetDirection(Vector2.right, spriteRendererRight);
        } else if(Input.GetKey (inputLeft))
        {
            SetDirection(Vector2.left, spriteRendererLeft);
        } else
        {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }
        OverSequence();
    }

    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = speed * direction * Time.fixedDeltaTime;
        rb.MovePosition(position + translation);
    }

    public void AddSpeed()
    {
        ++speed;
        statManager.DisplayString(statManager.speedValue, speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer(Mask) && isDeath == false)
        {
            DeathSequence();
            isDeath = true;
        } else if(collision.gameObject.layer == LayerMask.NameToLayer(Mask2) && isDeath == false)
        {
            DeathSequence();
            isDeath = true;
            ++score1;
            text1.text = score1.ToString();
        } else if(collision.gameObject.layer == LayerMask.NameToLayer(Mask3) && isDeath == false)
        {
            DeathSequence();
            isDeath = true;
            ++score2;
            text2.text = score2.ToString();
        } else if(collision.gameObject.layer == LayerMask.NameToLayer(Mask4) && isDeath == false)
        {
            DeathSequence();
            isDeath = true;
            ++score3;
            text3.text = score3.ToString();
        }
    }

    private void DeathSequence()
    {
        spriteRendererDown.enabled = false;
        spriteRendererUp.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererDeath.enabled = true;
        Invoke(nameof(DeathSequenceEnded), 1.25f);
    }

    private void DeathSequenceEnded()
    {
        gameObject.SetActive(false);
        Invoke(nameof(Reborn), 1.25f);
    }

    private void Reborn()
    {
        gameObject.SetActive(true);
        spriteRendererDeath.enabled = false;
        spriteRendererDown.enabled = true;
        spriteRendererUp.enabled = true;
        spriteRendererLeft.enabled = true;
        spriteRendererRight.enabled = true;
        isDeath = false;
    }

    private bool CheckIsOver()
    {
        if(score1 == 5)
        {
            isOver = true;
            winnerImage.sprite = sprite1;
        } else if(score2 == 5)
        {
            isOver = true;
            winnerImage.sprite = sprite2;
        } else if(score3 == 5)
        {
            isOver = true;
            winnerImage.sprite = sprite3;
        }
        return isOver;
    }

    private void ManageScore()
    {
        int score = Convert.ToInt32(yourScore.text);
        playerScore[0] = score;
        playerScore[1] = score1;
        playerScore[2] = score2;
        playerScore[3] = score3;
        Array.Sort(playerScore);
        if (playerScore[2] == score1)
        {
            secondImage.sprite = sprite1;
        } else if (playerScore[2] == score2)
        {
            secondImage.sprite = sprite2;
        } else if (playerScore[2] == score3)
        {
            secondImage.sprite= sprite3;
        } else if (playerScore[2] == score)
        {
            secondImage.sprite = yourSprite;
        }

        if (playerScore[1] == score1)
        {
            thirdImage.sprite = sprite1;
        } else if (playerScore[1] == score2)
        {
            thirdImage.sprite= sprite2;
        } else if (playerScore[1] == score3)
        {
            thirdImage.sprite= sprite3;
        } else if (playerScore[1] == score)
        {
            thirdImage.sprite = yourSprite;
        }

        if (playerScore[0] == score1)
        {
            fourthImage.sprite = sprite1;
        } else if (playerScore[0] == score2)
        {
            fourthImage.sprite= sprite2;
        } else if (playerScore[0] == score3)
        {
            fourthImage.sprite= sprite3;
        } else if (playerScore[0] == score)
        {
            fourthImage.sprite = yourSprite;
        } 
    }

    private void OverSequence()
    {
        if(CheckIsOver())
        {
            ManageScore();
            spriteRendererDown.enabled = false;
            spriteRendererUp.enabled = false;
            spriteRendererLeft.enabled = false;
            spriteRendererRight.enabled = false;
            spriteRendererDeath.enabled = true;
            Invoke(nameof(ChangeSceneAfterOver), 1f);
        }
    }

    private void ChangeSceneAfterOver()
    {
        Stage.SetActive(false);
        RewardScreen.SetActive(true);
    }

}
