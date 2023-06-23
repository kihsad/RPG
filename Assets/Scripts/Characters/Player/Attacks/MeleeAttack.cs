using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour // �������������� ������� �����(����� ����������� ����)
{
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _cooldown;
    [SerializeField]
    private float _attackRange;

    public float GetDamage => _damage;
    public float GetCooldown => _cooldown;
    public float GetAttackRange => _attackRange;

}