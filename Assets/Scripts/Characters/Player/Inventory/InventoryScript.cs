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

    private SlotScript _fromSlot;

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
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryScript>();
            }
            return instance;
        }
    }
    public SlotScript FromSlot
    {
        get
        {
            return _fromSlot;
        }
        set
        {
            _fromSlot = value;
            if(value!=null)
            {
                _fromSlot.MyIcon.color = Color.gray;
            }
        }
    }

    private void Awake()
    {
           Bag bag = (Bag)Instantiate(_items[0]);
            bag.Initialize(9);
            bag.Use();
            OpenClose();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Bag bag = (Bag)Instantiate(_items[0]);
            bag.Initialize(9);
            bag.Use();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Bag bag = (Bag)Instantiate(_items[0]);
            bag.Initialize(9);
            AddItem(bag);
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            HealthsPotion healthsPotion = (HealthsPotion)Instantiate(_items[1]);
            AddItem(healthsPotion);
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Player.MyInstance.MyHealth -= 10;
        }

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

    private void PlaceInEmpty(Item item)
    {
        foreach (Bag bag in _bags)
        {
            if (bag.MyBagScrtipt.AddItem(item))
            {
                return;
            }
        }
    }
        private bool PlaceInStack(Item item)
    {
        foreach(Bag bag in _bags)
        {
            foreach(SlotScript slot in bag.MyBagScrtipt.MySlots)
            {
                if(slot.StackItem(item))
                {
                    return true;
                }
            }
        }
        return false;
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

    public void AddItem(Item item)
    {
        if(item.MyStackSize > 0)
        {
            if(PlaceInStack(item))
            {
                return;
            }
        }
        PlaceInEmpty(item);
    }

}
