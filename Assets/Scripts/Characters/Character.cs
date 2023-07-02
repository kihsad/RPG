using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour //��������� (����������� ����� , ����� � ���)
{
    [SerializeField]
    protected Transform _hitBox; //���������
    [SerializeField]
    private Stats health;
    [SerializeField]
    private float _initHealth; //�� ��� ������
    [SerializeField]
    private string _typeStr;
    [SerializeField]
    private int _level;
    private Animator _animator;

    private Vector3 _offset = new Vector3(2,3,0);

    protected bool isAttacking = false;

    public bool IsAlive
    {
        get
        {
            return health.MyCurrentValue > 0;
        }
    }
    public string Type => _typeStr;
    public Transform HitBox => _hitBox;
    public Stats Health => health;
    public int Level
    {
        get
        {
            return _level;
        }
        set
        {
            _level = value;
        }
    }
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
        if(this as Enemy)
        CombatTextManager.Instance.CreateText(transform.position+_offset, damage.ToString(), SCtype.Damage);

        if (health.MyCurrentValue <= 0)
        {
            //die animation
            //loot
            KillManager.Instance.OnKillConfirmed(this);
            gameObject.GetComponent<NavMeshAgent>().enabled = false; //��� ������� �� �����
            _animator.SetBool("isDead", true);
            Invoke("Death", 2.5f);

            if(this is Enemy)
            {
                Player.MyInstance.GainXP(XpManager.CalculateExp(this as Enemy));
            }
        }
    }

    public void GetHealth(int health)
    {
        Health.MyCurrentValue += health;
        CombatTextManager.Instance.CreateText(transform.position+_offset, health.ToString(),SCtype.Heal);
    }
    public void Death()
    {
        _animator.GetComponent<Enemy>().OnCharacterRemoved();
    }
}
