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
    public abstract void UseItem(PlayerController player);
}
