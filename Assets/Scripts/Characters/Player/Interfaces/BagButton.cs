using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BagButton : MonoBehaviour,IPointerClickHandler
{

    private Bag _bag;

    [SerializeField]
    private Sprite _full, _empty;

    public Bag  MyBag
    {
        get
        {
            return _bag;
        }
        set
        {
            if(value!=null)
            {
                GetComponent <Image>().sprite = _full;
            }
            else
            {
                GetComponent<Image>().sprite = _empty;
            }
            _bag = value;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(_bag!=null)
        {
            _bag.MyBagScrtipt.OpenClose();
        }
    }
}
