using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vitamin : Item
{
    Vitamin()
    {
        itemType = ItemType.VITAMIN;
    }
    public override void UseItem(PlayerController player)
    {
        StartCoroutine(SpeedUp(player));
    }
    private IEnumerator SpeedUp(PlayerController player)
    {
        player.moveSpeed += 5;
        yield return new WaitForSeconds(5);
        player.moveSpeed -= 5;
    }
    private void OnCollisionEnter(Collision collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        UseItem(player);
        Destroy(gameObject);
    }
}
