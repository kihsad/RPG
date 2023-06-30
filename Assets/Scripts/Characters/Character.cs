using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour //��������� (����������� ����� , ����� � ���)
{
    [SerializeField]
    protected Transform _hitBox; //���������
    [SerializeField]
    public Stats health;
    [SerializeField]
    private float _initHealth; //�� ��� ������
    
    private Animator _animator;

    protected bool isAttacking = false;

    public bool IsAlive
    {
        get
        {
            return health.MyCurrentValue > 0;
        }
    }
    public Transform HitBox => _hitBox;
    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        health.Initialize(_initHealth, _initHealth); // ��� ui ��������
    }
    protected virtual void Update()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        health.MyCurrentValue -= damage;
        if (health.MyCurrentValue <= 0)
        {
            //die animation
            //loot
            gameObject.GetComponent<NavMeshAgent>().enabled = false; //��� ������� �� �����
            _animator.SetBool("isDead", true);
            Invoke("Death", 2.5f);
        }
    }

    public void Death()
    {
        _animator.GetComponent<NPC>().OnCharacterRemoved();
    }
}
