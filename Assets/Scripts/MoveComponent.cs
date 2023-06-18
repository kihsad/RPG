using UnityEngine;

namespace RPGPlayer
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _canBeClicked;
        private Player _player;
        private bool _isMoving = false;
        Animator _animator;
        private Vector3 _targetPosition;
        private float _distance=0f;
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
            _player = GetComponent<Player>();
            _animator = GetComponent<Animator>();
        }

        public void Moving()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(agentRay, out hitInfo, 100, _canBeClicked))
                {
                    _player.GetAgent.SetDestination(hitInfo.point);
                    _targetPosition = hitInfo.point;
                }
            }
        }
        private void Update()
        {
            _distance = Vector3.Distance(_targetPosition, _player.transform.position);
            if(_distance<=0.5)
            {
                IsMoving = false;
            }
            else
            {
                IsMoving = true;
            }
        }
    }
}
