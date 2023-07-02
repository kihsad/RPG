using UnityEngine;

[CreateAssetMenu(fileName ="HealthsPotion",menuName ="Items/Potion",order =1)]
public class HealthsPotion : Item, IUseable
{
    [SerializeField]
    private int _healValue;
    public void Use()
    {
        if(Player.MyInstance.Health.MyCurrentValue < Player.MyInstance.Health.MyMaxValue)
        Remove();
        Player.MyInstance.GetHealth(_healValue);
    }
    public override string GetDescription()
    {
        return base.GetDescription() + string.Format("\nUse: Restores {0} health.",_healValue);
    }
}
