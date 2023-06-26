using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour , IPointerClickHandler , IClickable
{
    [SerializeField]
    private Image _icon;

    private Stack<Item> _items = new Stack<Item>();

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
            UIBarManager.MyInstance.UpdateStackSize(this);
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
}
