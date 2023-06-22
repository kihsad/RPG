using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    [SerializeField]
    private GameObject _item;
    [SerializeField]
    private Sprite _icon;

    [SerializeField]
    private int _stackSize;

    private SlotScript _slot;

    public GameObject ItemGO => _item;
    public Sprite Icon => _icon;
    public int StackSize => _stackSize;
    protected SlotScript Slot
    {
        get
        {
            return _slot;
        }
        set
        {
            _slot = value;
        }
    }
}
