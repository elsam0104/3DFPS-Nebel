using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    ANTIBIOTIC,
    BLOODRAGS,
    VITAMIN,
    BULLET,
    BAG
}

public abstract class Item : MonoBehaviour
{
    public ItemType itemType;
    public abstract void UseItem();
}
interface HoldItem
{
    void HoldItem();
    void UseHoldItem();
}

public class Antibiotic : Item, HoldItem
{
    Antibiotic()
    {
        itemType = ItemType.ANTIBIOTIC;
    }
    public override void UseItem()
    {
        UseHoldItem();
    }
    public void HoldItem()
    {

    }

    public void UseHoldItem()
    {

    }

}
