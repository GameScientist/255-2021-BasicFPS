using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Summary: Singleton design pattern
public class ItemPickup : MonoBehaviour
{
    public void PlayerInteract()
    {
        // remember that the player has "picked up" the object
        Inventory.main.hasKey = true;

        // destroy this game object:
        Destroy(gameObject);
    }
}
