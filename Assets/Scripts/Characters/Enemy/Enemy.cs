using UnityEngine;

public delegate void CharacterRemoved();


public class Enemy : Character
{
    public event CharacterRemoved _characterRemoved;

    [SerializeField]
    private CanvasGroup _heathGroup;

    public Transform Select() // ��������� �� ��������
    {
        _heathGroup.alpha = 1;
        return _hitBox;
    }
    public void DeSelect() //��������� �� ��������
    {
        _heathGroup.alpha = 0;
    }

    public void OnCharacterRemoved()
    {
        if (_characterRemoved is not null)
        {
            _characterRemoved();
        }
        Destroy(gameObject);
    }

}
