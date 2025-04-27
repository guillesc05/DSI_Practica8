using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class PouClicker : MonoBehaviour
{
    private VisualElement _pou;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        _pou = root.Q<VisualElement>("pouImage");
        _pou.RegisterCallback<ClickEvent>(GetMoney);
    }

    void GetMoney(ClickEvent click)
    {
        Inventory.Instance.Money++;
    }
}
