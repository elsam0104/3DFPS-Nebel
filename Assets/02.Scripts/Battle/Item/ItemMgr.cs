using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMgr : MonoBehaviour
{
    [SerializeField]
    private GameObject[] itemObj;
    [SerializeField]
    private List<Transform> points = new List<Transform>();
    [SerializeField]
    private PlayerDataSO playerDataSO;

    private void Start()
    {
        foreach(Transform curT in points)
        {
            int i = Random.Range(0, 4);
            Instantiate(itemObj[i], curT.position, curT.rotation);
        }
    }
    
    public void PutItem(Item item)
    {
        if (playerDataSO.curItem + 1 >= playerDataSO.maxItem)
            Debug.Log("인벤토리 공간 부족");
        else
            playerDataSO.items.Add(item);
    }

}
