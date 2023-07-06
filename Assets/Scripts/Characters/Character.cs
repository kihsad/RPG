using System.Collections;
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
    [SerializeField]
    private Chest _chestPrefab;

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
    public int MyLevel
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

        if (this is Enemy && IsAlive)
        {
            _animator.SetTrigger("hit");
            transform.GetComponent<NavMeshAgent>().SetDestination(Player.MyInstance.transform.position);
        }

        if (_health.MyCurrentValue <= 0)
        {
            StartCoroutine(Death());
            _animator.SetBool("isDead", true);
            if(this is Enemy && !IsAlive && Player.MyInstance.MyTarget!=null)
            {
                Player.MyInstance.MyTarget = null;
                Player.MyInstance.GainXP(XpManager.CalculateExp(this as Enemy));
            }
        }
    }

    public void GetHealth(int health)
    {
        _health.MyCurrentValue += health;
        CombatTextManager.Instance.CreateText(transform.position+_offset, health.ToString(),SCtype.Heal);
    }
    public IEnumerator Death()
    {
        var go = Instantiate(_chestPrefab);
        go.transform.position = transform.position;
        yield return new WaitForSeconds(3f);
        KillManager.Instance.OnKillConfirmed(this);
        _animator.GetComponent<Enemy>().OnCharacterRemoved();
    }

}
