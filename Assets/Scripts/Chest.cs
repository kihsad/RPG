using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private List<Item> items;

    public List<Item> MyItems { get => items; set => items = value; }
    public BagScript Bag { get => bag; set => bag = value; }

    [SerializeField]
    private BagScript bag;

    private void Awake()
    {
        items = new List<Item>();
    }
}

