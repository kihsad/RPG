using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private Player _player;
    private Enemy _enemy;

    private MeleeAttack _meleeAtack;

    //private LayerMask _layerMask;
    //[SerializeField, Range(0, 1)]
    //private float _distance;

    //public Collider[] _targets = new Collider[10];

    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _meleeAtack = GetComponentInParent<MeleeAttack>();
        _enemy = FindObjectOfType<Enemy>();
        //_character = FindObjectOfType<Character>();
    }

    //private void Update()
    //{
    //    int numColliders = Physics.OverlapSphereNonAlloc(transform.position, _distance, _targets, _layerMask);
    //    if (numColliders == 0) return;
    //    foreach (Collider target in _targets)
    //    {
    //        OnTriggerEnter(target);
    //    }
    //    //for (int i = 0; i < numColliders; i++)
    //    //{
    //    //    OnTriggerEnter(_targets);
    //    //    _character.TakeDamage(GetComponent<MeleeAttack>().GetDamage);
    //    //}
    //}
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, _distance);
    //}
    private void OnTriggerEnter(Collider other) // коллизии с разными видами обьектов(но в целом только для енеми т.к. рейкаст с layer Enemy)
    {
        if(_meleeAtack._layerMask == 9)
        {
            var enemy = other.GetComponent<Enemy>();
            if (enemy is null)
            {
                return;
            }
            enemy.TakeDamage(_player.GetComponent<MeleeAttack>().GetDamage);
        }
        else
        {
            var player = other.GetComponent<Player>();
            if (player is null)
            {
                return;
            }
            player.TakeDamage(_enemy.GetComponent<MeleeAttack>().GetDamage);
        }
        //анимация полученя урона врага
        //aнимация попадания
    }
}
