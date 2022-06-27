using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : Item
{
    Bag()
    {
        itemType = ItemType.BAG;
    }
    public override void UseItem(PlayerController player)
    {
        player.playerDataSO.maxItem += 5;
    }
}
