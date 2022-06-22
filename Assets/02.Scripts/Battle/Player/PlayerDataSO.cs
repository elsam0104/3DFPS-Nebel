using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDataSO : ScriptableObject
{
    public int maxItem = 5;
    public int curItem = 0;
    public int maxMagazine = 40;
    public int curMagazine = 40;
    public List<Item> items = new List<Item>();
}
