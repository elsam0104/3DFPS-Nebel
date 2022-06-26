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
}
