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
public class Inventory
{
    private List<Item> items = new List<Item>();
    private int maxItem = 10;
    private int curItem = 0;
    public void PutItem(Item item)
    {
        if (curItem + 1 >= maxItem)
            Debug.Log("인벤토리 공간 부족");
        else
            items.Add(item);
    }
}
public abstract class Item : MonoBehaviour
{
    public ItemType itemType;
    public abstract void UseItem(PlayerController player);
}
interface HoldItem
{
    void HoldItem();
    void UseHoldItem();
}

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
