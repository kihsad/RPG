using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    [SerializeField]
    private LayerMask _isGround;

    public AudioClip movement;

    private float _distance;
    private int _touchCount;

    private Vector3 _targetPosition;

    private Player _player;
    private Animator _animator;

    private float _timer;

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

    private void Awake()
    {
        _timer = 0;
        _distance = 0f;
        _touchCount = 0;
        _player = GetComponent<Player>();
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        DistanceDetection();
        _timer += Time.deltaTime;
    }

    private void DistanceDetection()
    {
        _distance = Vector3.Distance(_targetPosition, _player.transform.position);
        if (_distance <= 0.5 || _touchCount == 0)
        {
            IsMoving = false;
        }
        else
        {
            IsMoving = true;
            if (_timer>=0.3f)
            {
                SoundManager.Instance.PlaySound(movement);
                _timer = 0;
            }
           
        }
    }

    public void Moving()
    {
        if (Input.GetMouseButtonDown(1))
        {
            _touchCount++;
            Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(agentRay, out hitInfo, 50, _isGround))
            {
                _player.GetAgent.SetDestination(hitInfo.point);
                _targetPosition = hitInfo.point;
            }
        }
    }
}
