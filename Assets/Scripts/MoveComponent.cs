using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace RPGPlayer
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _canBeClicked;
        private NavMeshAgent _agent;
        private Player _player;
        private bool _isMoving = false;
        Animator _animator;
        private Vector3 _targetPosition;
        public bool IsMoving
        {
            get
            {
                return _isMoving;
            }
            private set
            {
                _isMoving = value;
                _animator.SetBool("isMoving", value);
            }
        }
        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _player = GetComponent<Player>();
            _animator = GetComponent<Animator>();
        }

        //public void Moving()
        //{
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //        RaycastHit hitInfo;

        //        if (Physics.Raycast(agentRay, out hitInfo, 100, _canBeClicked))
        //        {
        //            _agent.SetDestination(hitInfo.point);
        //            IsMoving = true;
        //            _targetPosition = hitInfo.point;
        //        }
        //    }
        //    //else if (_agent.SetDestination(_targetPosition)== false) IsMoving = false;
        //    else if (transform.position == _targetPosition) IsMoving = false;
        //}
        public void Moving()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(agentRay, out hitInfo, 100, _canBeClicked))
                {
                    _player.GetAgent.SetDestination(hitInfo.point);
                    if (_player.GetAgent.SetDestination(hitInfo.point) == true)
                        IsMoving = true;
                    else
                        IsMoving = false;
                    _targetPosition = hitInfo.point;
                }
            }
        }
    }
}
