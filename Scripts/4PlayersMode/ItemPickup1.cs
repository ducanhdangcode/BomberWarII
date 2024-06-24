using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup1 : MonoBehaviour
{
    public enum ItemType
    {
        BonusBomb,
        BonusRadius, 
        BonusSpeed,
    }

    public ItemType type;

    private void OnItemPickup(GameObject player)
    {
        switch(type)
        {
            case ItemType.BonusSpeed:
                player.GetComponent<MovementController1>().AddSpeed();
                break;
            case ItemType.BonusRadius:
                player.GetComponent<BombController1>().AddRadius();
                break;
            case ItemType.BonusBomb:
                player.GetComponent<BombController1>().AddBomb();
                break;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            OnItemPickup(collision.gameObject);
        }
    }
}
