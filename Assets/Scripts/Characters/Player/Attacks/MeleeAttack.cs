using UnityEngine;

public class MeleeAttack : MonoBehaviour // �������������� ������� �����(����� ����������� ����)
{
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private float _attackRange;
    [SerializeField]
    private Character character;

    public float GetDamage => _damage;
    public float GetCooldown => _cooldown;
    public float GetAttackRange => _attackRange;
    public Character Character => character;

}
