using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private float timer;
    private Animator _animator;
    private List<Transform> _points = new List<Transform>();
    private NavMeshAgent _agent;
    void Start()
    {
        timer = 0;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        Transform pointsObject = FindObjectOfType<Point>().transform;
        foreach (Transform point in pointsObject)
            _points.Add(point);
        _agent.SetDestination(_points[0].position);
    }

    
    void Update()
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
            _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);
        timer += Time.deltaTime;
        if (timer > 10)
            _animator.SetBool("isPatrolling", false);
    }


}
