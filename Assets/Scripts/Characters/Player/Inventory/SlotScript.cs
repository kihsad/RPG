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

    public bool IsEmpty
    {
        get
        {
            return _items.Count == 0;
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
    private void UpdateSlot()
    {
        UIBarManager.MyInstance.UpdateStackSize(this); 
    }
}
