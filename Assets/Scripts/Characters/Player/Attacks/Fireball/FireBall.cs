using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FireBall : MonoBehaviour //скрипт для префаба
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _lifeTime=1f;
    [SerializeField]
    private int _damage;
    [SerializeField]
    private int _manaCost;
    [SerializeField]
    private float _cooldownSpell;
    [SerializeField]
    private Image _castingBar;

    public int ManaCost => _manaCost;
    public float FireCooldown => _cooldownSpell;
    public int FireDamage => (int)(_damage*Player.MyInstance.MyMana.MyMaxValue/10);

    private void Awake()
    {        
        StartCoroutine(DestroyFireBall());
    }
    private void Update()
    {
        transform.LookAt(Player.MyInstance.MyTarget);
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) // коллизии с разными видами обьектов(но в целом только для енеми т.к. рейкаст с layer Enemy)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy == null)
        {
            Destroy(gameObject);
            return;
        }
        enemy.TakeDamage(FireDamage);
        Destroy(gameObject);
    }

    private IEnumerator DestroyFireBall() // уничтожение обьекта через время
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
