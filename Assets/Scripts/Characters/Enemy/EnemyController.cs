using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private Transform _detector;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField, Range(0, 100)]
    private float _distance;


    private float _stoppingDistance = 5f;

    public Collider[] _targets = new Collider[10];
    public List<Transform> _points = new List<Transform>();

    private Animator _animator;
    private NavMeshAgent _agent;
    [SerializeField]
    private SwordAttack _sword;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _sword.gameObject.GetComponent<Collider>().enabled = false;

    }
    private void FixedUpdate()
    {
        Detect();
        SwordEnabled();
    }

    public void Detect()
    {
        int numColliders = Physics.OverlapSphereNonAlloc(_detector.position, _distance, _targets, _layerMask);
        if (numColliders == 0) return;
        float distance;
        for (int i = 0; i < numColliders; i++)
        {
            distance = Vector3.Distance(_agent.transform.position, _targets[i].ClosestPoint(transform.position));
            _agent.SetDestination(_targets[0].transform.position);
            if (distance <= _stoppingDistance)
            {
                _animator.SetBool("isAttacking", true);
                //transform.LookAt(_targets[0].transform);
            }
            else
            {
                _animator.SetBool("isPatrolling", true);
                _animator.SetBool("isAttacking", false);
            }
            if (distance > _distance)
            {
                _distance = 6f;
            }
            else
            {
                _distance = 15f;
            }
        }
    }
    private void SwordEnabled()
    {
        if (_animator.GetBool("isAttacking")&&!_animator.GetBool("isPatrolling"))
        { 
            _sword.gameObject.GetComponent<Collider>().enabled = true;
        }
        else
        {
            _sword.gameObject.GetComponent<Collider>().enabled = false;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_detector.position, _distance);
    }
}
