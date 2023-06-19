using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    private float timer;
    private List<Transform> _points = new List<Transform>();
    private NavMeshAgent _agent;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        _agent = animator.GetComponent<NavMeshAgent>();
        Transform pointsObject = FindObjectOfType<Point>().transform;
        foreach (Transform point in pointsObject)
            _points.Add(point);
        _agent.SetDestination(_points[0].position);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
            _agent.SetDestination(_points[Random.Range(0, _points.Count)].position);
        timer += Time.deltaTime;
        if (timer > 10)
            animator.SetBool("isPatrolling", false);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }

}
