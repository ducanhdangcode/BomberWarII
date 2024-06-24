using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSpriteRenderer : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    public float animationTime = 0.25f;
    public Sprite[] AnimationSprites;
    public Sprite idleSprite;
    private int animationFrame;


    public bool idle = true;
    public bool loop = true;

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

    private void Start()
    {
        InvokeRepeating(nameof(NextFrame), animationTime, animationTime);
    }

    private void NextFrame()
    {
        ++animationFrame;

        if(loop && animationFrame >= AnimationSprites.Length)
        {
            animationFrame = 0;
        }
        
        if(idle)
        {
            spriteRenderer.sprite = idleSprite;
        } else if(animationFrame >= 0 && animationFrame < AnimationSprites.Length)
        {
            spriteRenderer.sprite = AnimationSprites[animationFrame];
        }
    }
}
