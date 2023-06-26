using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandScript : MonoBehaviour
{

    public IMoveable IMoveable { get; set; }
    private static HandScript instance;
    private Image icon;

    private Vector3 _offset;

    private void Start()
    {
        _offset = new Vector3(20, 10, 0);
        icon = GetComponent<Image>();
    }
    private void Update()
    {
        icon.transform.position = Input.mousePosition + _offset ;
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
        this.IMoveable = moveable;
        icon.sprite = moveable.MyIcon;
        icon.color = Color.white;
    }
}
