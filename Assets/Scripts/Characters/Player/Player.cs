using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : Character // игрок
    {
        private NavMeshAgent _agent;
        private MoveComponent _moveComponent;
        private AttackComponent _attackComponent;

        public NavMeshAgent GetAgent => _agent;
        private static Player instance;

        [SerializeField]
        private GameObject[] _spellPrefabs; // для возможности замены файрболла

        [SerializeField]
        private Stats _mana;
        [SerializeField]
        private Stats _xpStat;
        [SerializeField]
        private Text _levelText;

        [SerializeField]
        private float _initMana;

        public Transform MyTarget { get; set; }

    public static Player MyInstance
        {
            get
            {
                if (instance == null) instance = FindObjectOfType<Player>();
                return instance;
            }
        }

    public Stats MyXp { get => _xpStat; set => _xpStat = value; }
    public Stats MyMana { get => _mana; set => _mana = value; }

    protected override void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _moveComponent = GetComponent<MoveComponent>();
        _attackComponent = GetComponent<AttackComponent>(); 
        base.Awake();
    }
    public void SetDefaultsValues()
    {
        _health.Initialize(_initHealth, _initHealth);
        _mana.Initialize(_initMana, _initMana);        
        _xpStat.Initialize(0, Mathf.Floor(100 * Level * Mathf.Pow(Level, 0.5f)));
        _levelText.text = Level.ToString();
    }
    protected override void Update()
        {
            _moveComponent.Moving();
            _attackComponent.Attacking();
            base.Update();
        }

    public void GainXP(int xp)
    {
        _xpStat.MyCurrentValue += xp;
        CombatTextManager.Instance.CreateText(this.transform.position,xp.ToString(),SCtype.XP);

        if (_xpStat.MyCurrentValue >= _xpStat.MyMaxValue)
        {
            StartCoroutine(Ding());
        }
    }
    private IEnumerator Ding()
    {
        while(!_xpStat.IsFull)
        {
            yield return null;
        }

        Level++;
        _levelText.text = Level.ToString();
        _xpStat.MyMaxValue = Mathf.Floor(100 * Level * Mathf.Pow(Level, 0.5f));
        _xpStat.MyCurrentValue = _xpStat.Overflow;
        _xpStat.Reset();
        if (_xpStat.MyCurrentValue >= _xpStat.MyMaxValue)
        {
            StartCoroutine(Ding());
        }
    }

    public void UpdateLevel()
    {
        _levelText.text = Level.ToString(); 
    }
    }
