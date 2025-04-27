using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hunger : MonoBehaviour
{
    Slider hunger;
    [SerializeField] float hungerDecreaseSpeed = 1.0f;
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        hunger = root.Q("background").Q("leftBar").Q<Slider>("hunger");
        hunger.value = 100;
        hunger.SetEnabled(false);
    }

    private void Update()
    {
        hunger.value -= hungerDecreaseSpeed * Time.deltaTime;
    }
}
