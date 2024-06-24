using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController2 : MonoBehaviour
{
    public new Rigidbody2D rb { private set; get; }
    private Vector2 direction = Vector2.down;
    public float speed = 5f;

    public KeyCode inputUp = KeyCode.W;
    public KeyCode inputDown = KeyCode.S;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode inputLeft = KeyCode.A;

    public AnimatedSpriteRenderer spriteRendererDown;
    public AnimatedSpriteRenderer spriteRendererUp;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;

    [Header("Opponent Parameters")]
    public GameObject opponent;

    [Header("Statistic Manager Parameters")]
    public StatManagerTimer PlayerSpeedManager;
    public StatManagerTimer OpponentSpeedManager;
    public StatManagerTimer OpponentScoreManager;

    [Header("Clock Parameters")]
    public DigitalClockManagement clock;

    [Header("Reborn Parameters")]
    public float initialSpeed = 5;
    public int initialBombAmount = 1;
    public int initialRadius = 1;

    private bool isDeath = false;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererDown;
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)
    {
        direction = newDirection;

        spriteRendererDown.enabled = spriteRenderer == spriteRendererDown;
        spriteRendererUp.enabled = spriteRenderer == spriteRendererUp;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    // update and handle the input
    private void Update()
    {
        if (Input.GetKey(inputUp))
        {
            SetDirection(Vector2.up, spriteRendererUp);
        }
        else if (Input.GetKey(inputDown))
        {
            SetDirection(Vector2.down, spriteRendererDown);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteRendererLeft);
        }
        else
        {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }
    }

    // fixed update and position of the player
    private void FixedUpdate()
    {
        Vector2 position = rb.position;
        Vector2 translation = direction * speed * Time.fixedDeltaTime;
        rb.MovePosition(position + translation);
    }

    public void AddSpeed()
    {
        ++speed;
        PlayerSpeedManager.DisplayFloat(speed);
    }

    public void ReduceSpeed()
    {
        --opponent.GetComponent<MovementController2>().speed;
        OpponentSpeedManager.DisplayFloat(opponent.GetComponent<MovementController2>().speed);
    }

    public void TimeReward()
    {
        clock.AddTime();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Explosion"))
        {
            isDeath = true;
            DeathSequence();
        }
    }

    private void DeathSequence()
    {
        spriteRendererDown.enabled = false;
        spriteRendererUp.enabled = false;
        spriteRendererLeft.enabled = false;
        spriteRendererRight.enabled = false;
        spriteRendererDeath.enabled = true;
        if(isDeath == true)
        {
            opponent.GetComponent<BombController2>().KillPlayer();
        }
        Invoke(nameof(DeathSequenceEnded), 1.25f);
    }

    private void DeathSequenceEnded()
    {
        gameObject.SetActive(false);
        Invoke(nameof(Reborn), 1f);
    }

    private void Reborn()
    {
        gameObject.SetActive(true);
        spriteRendererDown.enabled = true;
        spriteRendererUp.enabled = true;
        spriteRendererLeft.enabled = true;
        spriteRendererRight.enabled = true;
        spriteRendererDeath.enabled = false;
        isDeath = false;
        speed = initialSpeed;
        GetComponent<BombController2>().bombAmount = initialBombAmount;
        GetComponent<BombController2>().explosionRadius = initialRadius;
    }
}
