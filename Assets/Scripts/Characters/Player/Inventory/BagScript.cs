using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{

    [SerializeField]
    private GameObject _slotPrefab;

    private CanvasGroup _canvasGroup;

    private List<SlotScript> _slots = new List<SlotScript>(); 

    public bool IsOpen => _canvasGroup.alpha > 0;

    public List<SlotScript> MySlots => _slots;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public bool AddItem(Item item)
    {
        foreach(SlotScript slot in _slots )
        {
            if(slot.IsEmpty)
            {
                slot.AddItem(item);
                return true;
            }
        }
        return false;
    }
    public void AddSlots(int slotCount)
    {
        for(int i=0;i<slotCount;i++)
        {
            SlotScript slot = Instantiate(_slotPrefab, transform).GetComponent<SlotScript>();
            _slots.Add(slot);
        }
    }
    public void OpenClose()
    {
        _canvasGroup.alpha = _canvasGroup.alpha > 0 ? 0 : 1;
        _canvasGroup.blocksRaycasts = _canvasGroup.blocksRaycasts == true ? false : true;
    }

}
