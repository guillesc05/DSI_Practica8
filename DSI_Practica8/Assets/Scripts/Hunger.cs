using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Hunger : MonoBehaviour
{
    Slider hunger;
    [SerializeField] float hungerDecreaseSpeed = 2.0f;
    [SerializeField] AudioSource _pouTriste;
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

    private void AddFood(int foodValue)
    {
        hunger.value+= foodValue;
    }

    public bool TryAddFood(int foodValue)
    {
        if (hunger.value >= 98) { 
            _pouTriste.Play();
            return false;
        } 

        AddFood(foodValue);
        return true;
    }
}
