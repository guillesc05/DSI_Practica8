using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField] private int _money;
    [SerializeField] private int _kebab;
    public UnityEvent QuantityUpdated;

    public int Money { 
        get { return _money; } 
        set { 
            _money = value; 
            QuantityUpdated.Invoke();
        } 
    }

    public int Kebab { 
        get { return _kebab; } 
        set { 
            _kebab = value; 
            QuantityUpdated.Invoke();
        } 
    }
}
