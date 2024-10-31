using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpyroInventory : MonoBehaviour
{
    public int NumberOfGems { get; private set; }

    public UnityEvent<SpyroInventory> OnGemCollected;

    public void GemCollected()
    {
        NumberOfGems++;
        OnGemCollected.Invoke(this);
    }
}
