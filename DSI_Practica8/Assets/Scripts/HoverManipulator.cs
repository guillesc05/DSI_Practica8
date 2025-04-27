
using UnityEngine;
using UnityEngine.UIElements;

public class HoverManipulator : MouseManipulator
{
    public HoverManipulator()
    {
        activators.Add(new ManipulatorActivationFilter { button = MouseButton.RightMouse });
    }
    protected override void RegisterCallbacksOnTarget()
    {
        target.RegisterCallback<MouseOverEvent>(OnMouseOver);
        target.RegisterCallback<MouseOutEvent>(OnMouseOut);
    }

    protected override void UnregisterCallbacksFromTarget()
    {
        target.UnregisterCallback<MouseOverEvent>(OnMouseOver);
        target.UnregisterCallback<MouseOutEvent>(OnMouseOut);
    }

    private void OnMouseOver(MouseOverEvent mev)
    {
        target.style.borderBottomWidth = 10;
        target.style.borderTopWidth = 10;
        target.style.borderLeftWidth = 10;
        target.style.borderRightWidth = 10;

        target.style.borderBottomColor = Color.white;
        target.style.borderLeftColor = Color.white;
        target.style.borderRightColor = Color.white;
        target.style.borderTopColor = Color.white;
        mev.StopPropagation();
    }
    private void OnMouseOut(MouseOutEvent mev)
    {
        target.style.borderBottomWidth = 0;
        target.style.borderTopWidth = 0;
        target.style.borderLeftWidth = 0;
        target.style.borderRightWidth = 0;
        mev.StopPropagation();
    }
}
