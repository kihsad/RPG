using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HandScript : MonoBehaviour
{

    public IMoveable MyMoveable { get; set; }
    private static HandScript instance;
    private Image icon;

    private Vector3 _offset;

    private void Start()
    {
        _offset = new Vector3(35, 10, 0);
        icon = GetComponent<Image>();
    }
    private void Update()
    {
        icon.transform.position = Input.mousePosition + _offset ;
        DeleteItem();
    }
    public static HandScript Instance
    {
        get
        {
            if (instance is null)
            {
                instance = FindObjectOfType<HandScript>();
            }
            return instance;
        }
    }
    public void TakeMoveable(IMoveable moveable)
    {
        this.MyMoveable = moveable;
        icon.sprite = moveable.MyIcon;
        icon.color = Color.white;
    }
    public IMoveable Put()
    {
        IMoveable tmp = MyMoveable;
        MyMoveable = null;
        icon.color = new Color(0, 0, 0, 0);
        return tmp;
    }
    public void Drop()
    {
        MyMoveable = null;
        icon.color = new Color(0, 0, 0, 0);
    }
    public void DeleteItem()
    {
        if(Input.GetMouseButton(0)&&!EventSystem.current.IsPointerOverGameObject() &&Instance.MyMoveable!=null)
        {
            if(MyMoveable is Item && InventoryScript.Instance.FromSlot!=null)
            {
                (MyMoveable as Item).MySlot.Clear();
            }
            Drop();
            InventoryScript.Instance.FromSlot = null;
        }
    }
}
