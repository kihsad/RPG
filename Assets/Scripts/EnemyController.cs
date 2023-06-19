using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField, Range(0, 100)]
    private float distance;
    [SerializeField]
    private Transform _detector;

    private float stoppingDistance = 3f;

    private Collider[] _targets = new Collider[10];

    private Animator _animator;
    private List<Transform> _points = new List<Transform>();
    private NavMeshAgent _agent;

    //private Damager _damager;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        //_damager = GetComponent<Damager>();

    }
    private void FixedUpdate()
    {
        Detect();
    }

    public void Detect()
    {
        for (int i = 0; i < Physics.OverlapSphereNonAlloc(_detector.position, distance, _targets, _layerMask); i++)
        {
            _agent.SetDestination(_targets[0].ClosestPoint(transform.position));
            var _distance = Vector3.Distance(_agent.transform.position, _targets[0].ClosestPoint(transform.position));
            if (_distance <= stoppingDistance)
            {
                _animator.SetBool("isAttacking", true);
                _animator.SetBool("isPatrolling", false);
                //_damager.Attack();

            }
            else
            {
                _animator.SetBool("isPatrolling", true);
                _animator.SetBool("isAttacking", false);
            }

        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_detector.position, distance);
    }

}
