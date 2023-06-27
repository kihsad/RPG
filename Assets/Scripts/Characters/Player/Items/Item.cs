using UnityEngine;

public abstract class Item : ScriptableObject,IMoveable
{
    //[SerializeField]
    //private GameObject _item;

    [SerializeField]
    private Sprite _icon;

    [SerializeField]
    private int _stackSize;

    private SlotScript _slot;

    //public GameObject ItemGO => _item;

    public int MyStackSize => _stackSize;

    public SlotScript MySlot
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

    public Sprite MyIcon => _icon;

    public void Remove()
    {
         if(MySlot!=null)
        {
            MySlot.RemoveItem(this);
        }
    }
}
