using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private static InventoryScript instance;
    //for Debugging 
    [SerializeField]
    private Item[] _items;

    public static InventoryScript Instance
    {
        get
        {
            if(instance ==null)
            {
                instance = FindObjectOfType<InventoryScript>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        Bag bag = (Bag)Instantiate(_items[0]);
        bag.Initialize(4);
        bag.Use();
    }


}
