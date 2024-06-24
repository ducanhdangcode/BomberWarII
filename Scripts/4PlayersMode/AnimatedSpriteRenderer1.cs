using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpriteRenderer1 : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [Header("Sprite Renderer Parameter")]
    public float animationTime = 1f;
    public Sprite[] AnimationSprites;
    public Sprite idleSprite;

    private int animationFrame;

    public bool idle = false;
    public bool loop = false;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        spriteRenderer.enabled = true;
    }

    private void OnDisable()
    {
        spriteRenderer.enabled = false;
    }

    private void NextFrame()
    {
        ++animationFrame;

        if (loop && animationFrame >= AnimationSprites.Length)
        {
            animationFrame = 0;
        }

        if (idle)
        {
            spriteRenderer.sprite = idleSprite;
        }
        else if (animationFrame >= 0 && animationFrame < AnimationSprites.Length)
        {
            spriteRenderer.sprite = AnimationSprites[animationFrame];
        }
    }

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }
}
