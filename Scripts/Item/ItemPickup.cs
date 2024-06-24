using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb, 
        BlastRadius, 
        SpeedIncrease,
    }

    private StatManager statManager;

    public ItemType type;

    private float speedTemp;

    private void Start()
    {
        statManager = GetComponent<StatManager>();
    }

    private void OnItemPickup(GameObject player)
    {
        switch(type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombController>().AddBomb();
                break;

            case ItemType.BlastRadius:
                player.GetComponent<BombController>().AddRadius();
                break;

            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController>().AddSpeed();
                break;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            OnItemPickup(collision.gameObject);
        }
    }
}
