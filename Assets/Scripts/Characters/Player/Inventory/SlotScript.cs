using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour , IPointerClickHandler , IClickable
{
    [SerializeField]
    private Image _icon;

    private Stack<Item> items = new Stack<Item>();

    public bool IsEmpty
    {
        get
        {
            return items.Count == 0;
        }
    }

    public Item MyItem
    {
        get
        {
            if(!IsEmpty)
            {
                return items.Peek();
            }
            return null;
        }
    }

    public int MyCount
    {
        get
        {
            return items.Count;
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
        items.Push(item);
        _icon.sprite = item.MyIcon;
        _icon.color = Color.white;
        item.MySlot = this;
        return true;    
    }
    public void RemoveItem(Item item)
    {

       if(!IsEmpty)
        {
            items.Pop();
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
        if (MyItem is IUseable)
            (MyItem as IUseable).Use();
    }
}
