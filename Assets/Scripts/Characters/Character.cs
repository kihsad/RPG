using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour //персонажи (наследуются враги , игрок и нпц)
{
    [SerializeField]
    protected Transform _hitBox; //коллайдер
    [SerializeField]
    protected Stats _health;
    [SerializeField]
    protected float _initHealth; //хп при старте
    [SerializeField]
    private string _typeStr;
    [SerializeField]
    private int _level;
    private Animator _animator;

    private Vector3 _offset = new Vector3(2,3,0);

    protected bool _isAttacking = false;

    public bool IsAlive
    {
        get
        {
            return _health.MyCurrentValue > 0;
        }
    }
    public string Type => _typeStr;
    public Transform HitBox => _hitBox;
    public Stats MyHealth
    {
        get => _health;
        set => _health = value;
    }
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

    protected virtual void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    protected virtual void Update()
    {
    }

    public virtual void TakeDamage(float damage)
    {
        _health.MyCurrentValue -= damage;
        if(this as Enemy)
        CombatTextManager.Instance.CreateText(transform.position+_offset, damage.ToString(), SCtype.Damage);

        if (_health.MyCurrentValue <= 0)
        {
            //die animation
            //loot
            KillManager.Instance.OnKillConfirmed(this);
            //gameObject.GetComponent<NavMeshAgent>().enabled = false; //для падения на землю
            _animator.SetBool("isDead", true);
            Invoke("Death", 2.5f);

            if(this is Enemy && !IsAlive)
            {
                    Player.MyInstance.GainXP(XpManager.CalculateExp(this as Enemy));
            }
        }
    }

    public void GetHealth(int health)
    {
        _health.MyCurrentValue += health;
        CombatTextManager.Instance.CreateText(transform.position+_offset, health.ToString(),SCtype.Heal);
    }
    public void Death()
    {
        _animator.GetComponent<Enemy>().OnCharacterRemoved();
    }
}
