using UnityEngine;
using UnityEngine.AI;

public abstract class Character : MonoBehaviour //персонажи (наследуются враги , игрок и нпц)
{
    [SerializeField]
    protected Transform _hitBox; //коллайдер
    [SerializeField]
    protected Stats health;
    [SerializeField]
    private float _initHealth; //хп при старте
    
    private Animator _animator;

    protected bool isAttacking = false;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
        health.Initialize(_initHealth, _initHealth); // для ui элемента
    }
    protected virtual void Update()
    {
        
    }

    public virtual void TakeDamage(float damage)
    {
        health.MyCurrentValue -= damage;
        if(health.MyCurrentValue<=0)
        {
            //die animation
            //loot
            gameObject.GetComponent<NavMeshAgent>().enabled = false; //для падения на землю
            _animator.Play("An_Dead");
            Invoke("Death", 3f);
        }
    }

    public void Death()
    {
        _animator.GetComponent<NPC>().OnCharacterRemoved();
    }
}
