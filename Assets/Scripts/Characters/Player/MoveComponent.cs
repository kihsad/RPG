using UnityEngine;

namespace RPGPlayer
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _canBeClicked;

        private float _distance;
        public int _touchCount;

        private Vector3 _targetPosition;

        private Player _player;
        private Animator _animator;

        private bool _isMoving = false;
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
            _distance = 0f;
            _touchCount = 0;
            _player = GetComponent<Player>();
            _animator = GetComponent<Animator>();
        }
        private void Update()
        {
            DistanceDetection();
        }

        private void DistanceDetection()
        {
            _distance = Vector3.Distance(_targetPosition, _player.transform.position);
            if (_distance <= 0.5 || _touchCount==0)
            {
                IsMoving = false;
            }
            else
            {
                IsMoving = true;
            }
        }

        public void Moving()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _touchCount++;
                Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(agentRay, out hitInfo, 100, _canBeClicked))
                {
                    _player.GetAgent.SetDestination(hitInfo.point);
                    _targetPosition = hitInfo.point;
                }
            }
        }
    }
}
