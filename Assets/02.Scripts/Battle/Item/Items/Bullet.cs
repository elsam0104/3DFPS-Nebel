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
}
