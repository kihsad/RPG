using UnityEngine;
using UnityEngine.AI;

public class MoveComponent : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent _agent;
    [SerializeField]
    public Transform _point;
    private Platform[] _platforms;
    private Ray _ray;

    private void Start()
    {
        _platforms = FindObjectsOfType<Platform>();
    }

    public void Raycast()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        RaycastHit hit;
        foreach (Platform plarform in _platforms)
        {
            if (Physics.Raycast(_ray, out hit))
            {
                Debug.Log("hit");
                _point.transform.position = hit.point;
            }

        }
        _agent.SetDestination(_point.position);
    }

}
