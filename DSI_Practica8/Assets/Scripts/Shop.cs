using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Shop : MonoBehaviour
{
    private VisualElement _cartButton, _centerSpace, _pou, _shopVE;
    [SerializeField] private VisualTreeAsset _shopTemplate;
    
    private bool _shopOpen = false;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        _cartButton = root.Q<VisualElement>("shopButton");
        _centerSpace = root.Q<VisualElement>("middle");
        _pou = root.Q<VisualElement>("pouInfo");

        _cartButton.RegisterCallback<ClickEvent>(ToggleShop);
    }

    void ToggleShop(ClickEvent click)
    {
        if(_shopOpen)
        {
            _centerSpace.Remove(_shopVE);
            _pou.style.display = DisplayStyle.Flex;
        }
        else
        {
            _pou.style.display= DisplayStyle.None;
            CreateShop();
        }

        _shopOpen = !_shopOpen;
    }

    void BuyKebab(ClickEvent click)
    {
        if(Inventory.Instance.Money >= 2)
        {
            Inventory.Instance.Money -= 2;
            Inventory.Instance.Kebab++;
        }
    }

    void CreateShop()
    {
        _shopVE = _shopTemplate.Instantiate();

        _shopVE.style.width = 500;
        _shopVE.style.height = 600;

        VisualElement buyButton = _shopVE.Q<VisualElement>("button1");
        buyButton.RegisterCallback<ClickEvent>(BuyKebab);

        VisualElement closeButton = _shopVE.Q<VisualElement>("button2");
        closeButton.RegisterCallback<ClickEvent>(ToggleShop);

        _centerSpace.Add(_shopVE);
    }
}
