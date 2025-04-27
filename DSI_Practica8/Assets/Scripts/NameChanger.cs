using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NameChanger : MonoBehaviour
{
    private TextElement _name;
    private VisualElement _button;
    private TextField _nameTextField;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        _name = root.Q<TextElement>("pouName");
        _button = root.Q<VisualElement>("nameButton");
        _nameTextField = root.Q<TextField>("newName");

        _button.RegisterCallback<ClickEvent>(ChangeName);
    }

    void ChangeName(ClickEvent click)
    {
        _name.text = _nameTextField.value;
    }
}
