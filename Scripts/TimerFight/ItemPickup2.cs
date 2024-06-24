using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup2 : MonoBehaviour
{
    

    public enum ItemType
    {
        ExtraBomb,
        BlastRadius,
        SpeedIncrease,
        FreezeBuff,
        AddTime,
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
        switch (type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombController2>().AddBomb();
                break;

            case ItemType.BlastRadius:
                player.GetComponent<BombController2>().AddRadius();
                break;

            case ItemType.SpeedIncrease:
                player.GetComponent<MovementController2>().AddSpeed();
                break;
            case ItemType.FreezeBuff:
                player.GetComponent<MovementController2>().ReduceSpeed();
                break;
            case ItemType.AddTime:
                player.GetComponent<MovementController2>().TimeReward();
                break;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            OnItemPickup(collision.gameObject);
        }
    }
}
