using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InventoryListener : MonoBehaviour
{
    private TextElement _moneyAmount, _kebabAmount;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        _moneyAmount = root.Q<TextElement>("coinNumber");
        _kebabAmount = root.Q<TextElement>("foodNumber");

        Inventory.Instance.QuantityUpdated.AddListener(UpdateDisplay);
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        _moneyAmount.text = $"x{Inventory.Instance.Money}";
        _kebabAmount.text = $"x{Inventory.Instance.Kebab}";
    }

}
