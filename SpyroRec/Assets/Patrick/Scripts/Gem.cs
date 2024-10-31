using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        SpyroInventory _inventory = other.GetComponent<SpyroInventory>();

        if (_inventory != null)
        {
            _inventory.GemCollected();
            gameObject.SetActive(false);
        }
    }


}
