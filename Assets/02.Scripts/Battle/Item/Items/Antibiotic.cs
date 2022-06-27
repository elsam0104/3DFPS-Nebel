using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antibiotic : Item
{
    Antibiotic()
    {
        itemType = ItemType.ANTIBIOTIC;
    }
    public override void UseItem(PlayerController player)
    {
        player.CurrentHp += 10;
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        UseItem(player);
        Destroy(gameObject);
    }
}
