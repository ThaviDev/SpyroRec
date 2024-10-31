using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI _gemText;

    void Start()
    {
        _gemText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateGemText(SpyroInventory _inventory)
    {
        _gemText.text = _inventory.NumberOfGems.ToString();
    }
}
