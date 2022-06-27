using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Item
{
    Bullet()
    {
        itemType = ItemType.BULLET;
    }
    public override void UseItem(PlayerController player)
    {
        player.playerDataSO.maxMagazine += 5;
        player.playerDataSO.curMagazine = player.playerDataSO.maxMagazine;
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        UseItem(player);
        Destroy(gameObject);
    }
}
