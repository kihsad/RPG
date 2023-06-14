using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private LayerMask _canBeClicked;
    private NavMeshAgent _agent;
    private MoveComponent _moveComponent;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _moveComponent = GetComponent<MoveComponent>();
    }
    private void Update()
    {
        _moveComponent.Raycast();
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hitInfo;

        //    if(Physics.Raycast(agentRay,out hitInfo,100,_canBeClicked))
        //    {
        //        transform.LookAt(hitInfo.point);
        //        _agent.SetDestination(hitInfo.point);
        //    }
        //    }
    }
}
