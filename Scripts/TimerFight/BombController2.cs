using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.Tilemaps;

public class BombController2 : MonoBehaviour
{
    public GameObject bombPrefab;

    public int bombAmount = 1;

    public float bombFuseTime = 3f;

    private int bombRemaining;

    public KeyCode inputKey = KeyCode.Space;

    public float floatingX = 0.3f;

    public float floatingY = 0.3f;

    public Explosion explosionPrefab;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;
    public LayerMask groundLayer;

    [Header("Tiles Parameters")]
    public Destructible destructiblePrefab;
    public Tilemap destructibleTiles;

    [Header("Statistic Manager")]
    public StatManagerTimer BombManager;
    public StatManagerTimer RadiusManager;
    public StatManagerTimer ScoreManager;

    [Header("Score Parameters")]
    private int score = 0;
    public int ScoreReward = 25;
    public int ScoreKill = 50;

    private bool isDestroyDestructible = false;

    private void OnEnable()
    {
        bombRemaining = bombAmount;
    }

    private void Update()
    {
        if (Input.GetKeyDown(inputKey) && bombRemaining > 0)
        {
            // place bomb
            StartCoroutine(PlaceBomb());
        }
    }

    IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        position.y -= floatingY;
        position.x -= floatingX;
        // spawn the clone
        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        //--bombRemaining;
        ReduceBomb();
        yield return new WaitForSeconds(bombFuseTime);

        position = bomb.transform.position;
        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveSpriteRenderer(explosion.start);
        Destroy(explosion.gameObject, explosionDuration);

        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);

        Destroy(bomb);
        ReBomb();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            collision.isTrigger = false;
        }
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if (length <= 0)
        {
            return;
        }

        position += direction;

        if (Physics2D.OverlapBox(position, Vector2.one / 2f, 0f, groundLayer))
        {
            isDestroyDestructible = true;
            if(isDestroyDestructible == true)
            {
                isDestroyDestructible = false;
            }
            ClearDestructible(position);
            return;
        }

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveSpriteRenderer(length > 1 ? explosion.middle : explosion.end);
        explosion.SetDirection(direction);

        Destroy(explosion.gameObject, explosionDuration);

        Explode(position, direction, length - 1);
    }

    private void ClearDestructible(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);
        if (tile != null)
        {
            Instantiate(destructiblePrefab, position, Quaternion.identity);
            destructibleTiles.SetTile(cell, null);
            AddScore();
        }
    }

    public void AddBomb()
    {
        ++bombAmount;
        ++bombRemaining;
        BombManager.DisplayInteger(bombRemaining);
    }

    private void ReduceBomb()
    {
        --bombRemaining;
        BombManager.DisplayInteger(bombRemaining);
    }

    private void ReBomb()
    {
        ++bombRemaining;
        BombManager.DisplayInteger(bombRemaining);
    }

    public void AddRadius()
    {
        ++explosionRadius;
        RadiusManager.DisplayInteger(explosionRadius);
    }

    public void AddScore()
    {
        score += ScoreReward;
        ScoreManager.DisplayInteger(score);
    }

    public void KillPlayer()
    {
        score += ScoreKill;
        ScoreManager.DisplayInteger(score);
    }

    public int GetScore()
    {
        return score;
    }
}
