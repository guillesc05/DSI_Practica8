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
        img.AddManipulator(new FoodManipulator(root, GetComponent<Hunger>()));
        LoadInventoryFromJSON();
        GetComponent<InventoryListener>().UpdateDisplay();
    }

    void LoadInventoryFromJSON()
    {
        var data = System.IO.File.ReadAllText(Application.persistentDataPath + "inventory.json");

        if (data.Length > 0)
        {
            Debug.Log(data);
            var inv = Inventory.Instance;
            JsonUtility.FromJsonOverwrite(data, inv);
        }
    }

    private void OnDestroy()
    {
        SaveInventory();
    }

    void SaveInventory()
    {
        string savedData = JsonUtility.ToJson(Inventory.Instance);
        Debug.Log(savedData);

        System.IO.File.WriteAllText(Application.persistentDataPath + "inventory.json", savedData);
        
    }
}
