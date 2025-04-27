using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class FoodManipulator : PointerManipulator
{
    public bool m_Hover;

    VisualElement pou;

    Hunger pouHunger;
    public FoodManipulator(VisualElement _root, Hunger _hunger)
    {
        pou = _root.Q("background").Q("middle").Q("pouInfo").Q("pouImage");
        pouHunger = _hunger;
    }

    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<PointerUpEvent>(OnPointerUp);
        target.RegisterCallback<MouseOverEvent>(OnMouseOver);
        target.RegisterCallback<MouseOutEvent>(OnMouseOut);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<PointerUpEvent>(OnPointerUp);
        target.UnregisterCallback<MouseOverEvent>(OnMouseOver);
        target.UnregisterCallback<MouseOutEvent>(OnMouseOut);
    }

    void OnPointerUp(PointerUpEvent e)
    {
        if (m_Hover && pou.worldBound.Contains(e.position))
        {
            Debug.Log(e.position);
            Debug.Log("pou fed");
            pouHunger.addFood(10);
        }
    }

    void OnMouseOver(MouseOverEvent mev)
    {
        m_Hover = true;
    }

    void OnMouseOut(MouseOutEvent mev)
    {
        m_Hover = false;
    }
}
