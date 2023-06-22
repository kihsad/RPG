using UnityEngine;

public class Enemy : NPC
{
    [SerializeField]
    private CanvasGroup _heathGroup;

    public override Transform Select() // ��������� �� ��������
    {
        _heathGroup.alpha = 1;
        return base.Select();
    }
    public override void DeSelect() //��������� �� ��������
    {
        _heathGroup.alpha = 0;
        base.DeSelect();
    }
}
