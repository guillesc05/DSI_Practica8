using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;


public class Practica8 : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement img = root.Q("background").Q("rightBar").Q("foodContainer").Q("foodImage");


        img.AddManipulator(new ExampleDragger());
        img.AddManipulator(new HoverManipulator());
    }
}
