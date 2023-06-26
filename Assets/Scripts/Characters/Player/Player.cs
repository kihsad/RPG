using UnityEngine;
using UnityEngine.AI;

    public class Player : Character // игрок
    {
        private NavMeshAgent _agent;
        private MoveComponent _moveComponent;
        private AttackComponent _attackComponent;

        public NavMeshAgent GetAgent => _agent;
        private static Player instance;
        private int _level;

        [SerializeField]
        private GameObject[] _spellPrefabs; // для возможности замены файрболла

        [SerializeField]
        private Stats _mana;

        private float _initMana=50;

       // private float _healthValue;

        public float MyHealth
        {
            get
            {
                return health.MyCurrentValue;
            }
            set
            {
                health.MyCurrentValue = value;
            }
        }
        public int MyLevel
        {
            get
                {
                return _level;
            }
            set {
                _level = value;
                    }
        }
        public static Player MyInstance
        {
            get
            {
                if (instance is null) instance = FindObjectOfType<Player>();
                return instance;
            }
        }


        protected override void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _moveComponent = GetComponent<MoveComponent>();
            _attackComponent = GetComponent<AttackComponent>();

            
            _mana.Initialize(_initMana, _initMana);
            base.Start();
        }
        protected override void Update()
        {
            _moveComponent.Moving();
            _attackComponent.Attacking();
            base.Update();
        }
    }
