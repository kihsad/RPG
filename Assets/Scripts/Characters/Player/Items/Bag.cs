using UnityEngine;

[CreateAssetMenu(fileName ="Bag", menuName = "Items/Bag",order =1)]
public class Bag : Item ,IUseable
{
    private int _slots;

    [SerializeField]
    private GameObject _bagPrefab;

    public BagScript MyBagScrtipt { get; set; }
    public BagButton MyBagButton { get; set; }

    public int Slots => _slots;

    public void Initialize(int slots)
    {
        _slots = slots;
    }

    public void SetupScript()
    {
        MyBagScrtipt = Instantiate(_bagPrefab, InventoryScript.Instance.transform).GetComponent<BagScript>();
        MyBagScrtipt.AddSlots(_slots);
    }

    public void Use()
    {
        if (InventoryScript.Instance.CanAddBag)
        {
            Remove();
            MyBagScrtipt = Instantiate(_bagPrefab, InventoryScript.Instance.transform).GetComponent<BagScript>();
            MyBagScrtipt.AddSlots(_slots);

            if(MyBagButton == null)
            {
                InventoryScript.Instance.AddBag(this);
            }
            else
            {
                InventoryScript.Instance.AddBag(this, MyBagButton);
            }
        }
    }
}