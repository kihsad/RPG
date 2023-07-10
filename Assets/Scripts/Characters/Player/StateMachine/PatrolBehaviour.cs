using UnityEngine;
using UnityEngine.AI;

public class PatrolBehaviour : StateMachineBehaviour
{
    private float timer;
    //[SerializeField]
    //private List<Transform> _points = new List<Transform>();
    private NavMeshAgent _agent;
    private EnemyController _enemyController;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _enemyController = animator.GetComponent<EnemyController>();
        timer = 0;
        _agent = animator.GetComponent<NavMeshAgent>();
        Transform pointsObject = FindObjectOfType<Point>().transform;
        _agent.SetDestination(_enemyController._points[0].position);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
            _agent.SetDestination(_enemyController._points[Random.Range(0, _enemyController._points.Count)].position);
        //distance = Vector3.Distance(_agent.transform.position, _targets[i].ClosestPoint(transform.position));
        timer += Time.deltaTime;
        if (timer > Random.Range(3,10))
            animator.SetBool("isPatrolling", false);
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }

}
