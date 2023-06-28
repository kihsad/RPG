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

   /* public Sprite MyIcon => throw new System.NotImplementedException();*/

    public void Initialize(int slots)
    {
        _slots = slots;
    }

    public void Use()
    {
        if (InventoryScript.Instance.CanAddBag)
        {
            Debug.Log("Bag/Use");
            Remove();
            MyBagScrtipt = Instantiate(_bagPrefab, InventoryScript.Instance.transform).GetComponent<BagScript>();
            MyBagScrtipt.AddSlots(_slots);
            InventoryScript.Instance.AddBag(this);
        }
    }
}