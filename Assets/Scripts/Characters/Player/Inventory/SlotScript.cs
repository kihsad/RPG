using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour , IPointerClickHandler , IClickable
{
    [SerializeField]
    private Image _icon;
    [SerializeField]
    private Text _stackSize;

    private ObservableStack<Item> _items = new ObservableStack<Item>();
    public ObservableStack<Item> MyItems
    {
        get
        {
            return _items;
        }
    }

    public bool IsEmpty
    {
        get
        {
            return _items.Count == 0;
        }
    }
    public bool IsFull
    {
        get
        {
            if(IsEmpty||MyCount<MyItem.MyStackSize)
            {
                return false;
            }
            return true;
        }
    }

    public Item MyItem
    {
        get
        {
            if(!IsEmpty)
            {
                return _items.Peek();
            }
            return null;
        }
    }
    public int MyCount
    {
        get
        {
            return _items.Count;
        }
    }
    public Image MyIcon
    {
        get
        {
            return _icon;
        }
        set
        {
            _icon = value;
        }
    }
    public Text MyStackText => _stackSize;
    public BagScript MyBag { get; set; }

    private void Awake()
    {
        _items.OnPop += new UpdateStackEvent(UpdateSlot);
        _items.OnPush += new UpdateStackEvent(UpdateSlot);
        _items.OnClear += new UpdateStackEvent(UpdateSlot);
    }

    public bool AddItem(Item item)
    {
        _items.Push(item);
        _icon.sprite = item.MyIcon;
        _icon.color = Color.white;
        item.MySlot = this;
        return true;    
    }
    public bool AddItems(ObservableStack<Item> newItems)
    {
        if(IsEmpty||newItems.Peek().GetType() == MyItem.GetType())
        {
            int count = newItems.Count;

            for(int i=0;i<count;i++)
            {
                if(IsFull)
                {
                    return false;
                }

                AddItem(newItems.Pop());
            }
            return true;
        }
        return false;
    }
    private bool PutItemBack()
    {
        if(InventoryScript.Instance.FromSlot == this)
        {
            InventoryScript.Instance.FromSlot.MyIcon.color = Color.white;
            return true;
        }
        return false;
    }
    public void RemoveItem(Item item)
    {
        if(!IsEmpty)
        {
            Debug.Log("remove");
            _items.Pop();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (InventoryScript.Instance.FromSlot == null && !IsEmpty)
            {
                HandScript.Instance.TakeMoveable(MyItem as IMoveable);
                InventoryScript.Instance.FromSlot = this;
            }
            else if(InventoryScript.Instance.FromSlot ==null && IsEmpty && (HandScript.Instance.MyMoveable is Bag))
            {
                Bag bag = (Bag)HandScript.Instance.MyMoveable;

                if (bag.MyBagScrtipt != MyBag && InventoryScript.Instance.MyEmptySlotCount - bag.Slots>0)
                {
                    AddItem(bag);
                    bag.MyBagButton.RemoveBag();
                    HandScript.Instance.Drop();
                }
            }
            else if (InventoryScript.Instance.FromSlot != null)
            {
                if (PutItemBack() || MergeItems(InventoryScript.Instance.FromSlot)|| SwapItems(InventoryScript.Instance.FromSlot)||AddItems(InventoryScript.Instance.FromSlot._items))
                {
                    HandScript.Instance.Drop();
                    InventoryScript.Instance.FromSlot = null;
                }
            }
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            UseItem();
        }
    }

    public void UseItem()
    {
        Debug.Log("Use");
        if (MyItem is IUseable)
        {
            (MyItem as IUseable).Use();
        }
    }

    public bool StackItem(Item item)
    {
        if(!IsEmpty&&item.name == MyItem.name&&_items.Count<MyItem.MyStackSize)
        {
            _items.Push(item);
            item.MySlot = this;
            return true;
        }
        return false;
    }
    private bool SwapItems(SlotScript from)
    {
        if (IsEmpty) return false;
        if(from.MyCount.GetType()!=MyItem.GetType()||from.MyCount+MyCount>MyItem.MyStackSize)
        {
            ObservableStack<Item> tmpFrom = new ObservableStack<Item>(from._items);
            from._items.Clear();
            from.AddItems(_items);
            _items.Clear();
            AddItems(tmpFrom);
            return true;
        }
        return false;
    }
    private bool MergeItems(SlotScript from)
    {
        if (IsEmpty) return false;

        if(from.MyItem.GetType() == MyItem.GetType() && !IsFull)
        {
            int free = MyItem.MyStackSize - MyCount;

            for(int i =0;i<free;i++)
            {
                AddItem(from._items.Pop());
            }
            return true;
        }
        return false; 
    }

    private void UpdateSlot()
    {
        UIBarManager.MyInstance.UpdateStackSize(this); 
    }
    public void Clear()
    {
        if(_items.Count>0)
        {
            _items.Clear();
        }
    }
}
