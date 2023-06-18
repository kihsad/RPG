using UnityEngine;
using UnityEngine.AI;

namespace RPGPlayer
{
    public class Player : MonoBehaviour
    {
        private NavMeshAgent _agent;
        private MoveComponent _moveComponent;

        public NavMeshAgent GetAgent => _agent;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _moveComponent = GetComponent<MoveComponent>();
        }
        private void Update()
        {
            //if(_moveComponent.IsMoving)
            _moveComponent.Moving();
        }
    }
}
