using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryListener : MonoBehaviour
{
    private TextElement _moneyAmount, _kebabAmount;
    [SerializeField] private Inventory _inventory;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        _moneyAmount = root.Q<TextElement>("coinNumber");
        _kebabAmount = root.Q<TextElement>("foodNumber");

        _inventory.QuantityUpdated.AddListener(UpdateDisplay);
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        _moneyAmount.text = $"x{_inventory.Money}";
        _kebabAmount.text = $"x{_inventory.Kebab}";
    }

}
