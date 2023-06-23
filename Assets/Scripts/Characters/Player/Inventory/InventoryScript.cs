using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    private static InventoryScript instance;
    //for Debugging 
    [SerializeField]
    private BagButton[] _bagButtons;
    [SerializeField]
    private Item[] _items;

    private List<Bag> _bags = new List<Bag>(); 
    public bool CanAddBag
    {
        get
        {
            return _bags.Count < 1;
        }
    }

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
            bag.Initialize(9);
            bag.Use();
        OpenClose();
    }
    public void AddBag(Bag bag)
    {
        foreach(BagButton bagButton in _bagButtons)
        {
            if(bagButton.MyBag==null)
            {
                bagButton.MyBag = bag;
                _bags.Add(bag);
                break;
            }
        }
    }
    public void OpenClose()
    {
        bool closedBag = _bags.Find(x => !x.MyBagScrtipt.IsOpen);
        foreach (Bag bag in _bags)
        {
            if (bag.MyBagScrtipt.IsOpen!=closedBag)
            {
                bag.MyBagScrtipt.OpenClose();
            }
        }
    }

}
