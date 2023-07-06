using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BearController : MonoBehaviour
{
    [SerializeField]
    private Transform _detector;
    [SerializeField]
    private LayerMask _layerMask;
    [SerializeField, Range(0, 100)]
    private float _distance;

    private float _stoppingDistance = 5f;

    public Collider[] _targets = new Collider[10];

    private Animator _animator;
    private NavMeshAgent _agent;

    [SerializeField]
    private SwordAttack _sword;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();

    }
    private void FixedUpdate()
    {
        Detect();
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
            }
            else
            {
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_detector.position, _distance);
    }
}
