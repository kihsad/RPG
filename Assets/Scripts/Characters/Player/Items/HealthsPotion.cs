using UnityEngine;

[CreateAssetMenu(fileName ="HealthsPotion",menuName ="Items/Potion",order =1)]
public class HealthsPotion : Item, IUseable
{
    [SerializeField]
    private int _healValue;
    public void Use()
    {
        if(Player.MyInstance.health.MyCurrentValue < Player.MyInstance.health.MyMaxValue)
        Remove();
        Player.MyInstance.MyHealth += _healValue;
    }
}
