using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloodrags : Item
{
    Bloodrags()
    {
        itemType = ItemType.BLOODRAGS;
    }
    public override void UseItem(PlayerController player)
    {
        player.IsHide = true;
    }
}
