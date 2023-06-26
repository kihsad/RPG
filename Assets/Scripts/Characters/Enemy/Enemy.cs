using UnityEngine;

public class Enemy : NPC
{
    [SerializeField]
    private CanvasGroup _heathGroup;

    private Enemy instance;

    public override Transform Select() // подсветка хп элемента
    {
        _heathGroup.alpha = 1;
        return base.Select();
    }
    public override void DeSelect() //затухание хп элемента
    {
        _heathGroup.alpha = 0;
        base.DeSelect();
    }
}
