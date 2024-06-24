using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombController1 : MonoBehaviour
{
    public GameObject bombPrefab;

    public int bombAmount = 1;

    public float bombFuseTime = 3f;

    private int bombRemaining;

    public KeyCode inputKey = KeyCode.Space;

    public float floatingX = 0.1f;

    public float floatingY = 0.25f;

    public Explosion explosionPrefab;
    public float explosionDuration = 1f;
    public int explosionRadius = 1;
    public LayerMask groundLayer;

    public Destructible destructiblePrefab;
    public Tilemap destructibleTiles;

    private StatManager statManager;

    [Header("Sound Parameters")]
    public AudioClip PlaceBombSound;
    public AudioClip ExplosionSound;

    private void Start()
    {
        statManager = GetComponent<StatManager>();
    }

    private void OnEnable()
    {
        bombRemaining = bombAmount;
    }

    private void Update()
    {
        if(bombRemaining > 0 && Input.GetKeyDown(inputKey))
        {
            StartCoroutine(PlaceBomb());
        }
    }

    IEnumerator PlaceBomb()
    {
        Vector2 position = transform.position;
        position.y -= floatingY;
        position.x -= floatingX;

        GameObject bomb = Instantiate(bombPrefab, position, Quaternion.identity);
        --bombRemaining;
        SoundManager.instance.PlaySound(PlaceBombSound);
        statManager.DisplayString(statManager.bombValue, bombRemaining);
        yield return new WaitForSeconds(bombFuseTime);

        position = bomb.transform.position;
        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveSpriteRenderer(explosion.start);
        Destroy(explosion.gameObject, explosionDuration);

        Explode(position, Vector2.up, explosionRadius);
        Explode(position, Vector2.down, explosionRadius);
        Explode(position, Vector2.right, explosionRadius);
        Explode(position, Vector2.left, explosionRadius);

        Destroy(bomb);
        ++bombRemaining;
        statManager.DisplayString(statManager.bombValue, bombRemaining);
    }

    private void Explode(Vector2 position, Vector2 direction, int length)
    {
        if(length <= 0)
        {
            return;
        }

        position += direction;

        if(Physics2D.OverlapBox(position, Vector2.one/2f, 0f, groundLayer))
        {
            ClearDestructibles(position);
            return;
        }

        Explosion explosion = Instantiate(explosionPrefab, position, Quaternion.identity);
        explosion.SetActiveSpriteRenderer(length > 1 ? explosion.middle : explosion.end);
        explosion.SetDirection(direction);
        SoundManager.instance.PlaySound(ExplosionSound);

        Destroy(explosion.gameObject, explosionDuration);

        Explode(position, direction, length - 1);
    }

    private void ClearDestructibles(Vector2 position)
    {
        Vector3Int cell = destructibleTiles.WorldToCell(position);
        TileBase tile = destructibleTiles.GetTile(cell);
        if (tile != null)
        {
            Instantiate(destructiblePrefab, position, Quaternion.identity);
            destructibleTiles.SetTile(cell, null);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Bomb"))
        {
            collision.isTrigger = false;
        }
    }

    public void AddBomb()
    {
        ++bombAmount;
        ++bombRemaining;
        statManager.DisplayString(statManager.bombValue, bombRemaining);
    }

    public void AddRadius()
    {
        ++explosionRadius;
        statManager.DisplayString(statManager.radiusValue, explosionRadius);
    }
}
