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
    [SerializeField]
    private PlayerDataSO playerDataSO;
    public void PutItem(Item item)
    {
        if (playerDataSO.curItem + 1 >= playerDataSO.maxItem)
            Debug.Log("�κ��丮 ���� ����");
        else
            playerDataSO.items.Add(item);
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
