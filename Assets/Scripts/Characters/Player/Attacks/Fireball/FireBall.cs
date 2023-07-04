using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FireBall : MonoBehaviour //������ ��� �������
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _lifeTime=1f;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private float _cooldownSpell;
    [SerializeField]
    private Image _castingBar;

    public float GetCooldown => _cooldownSpell;
    public float GetDamage => _damage;

    private void Awake()
    {        
        StartCoroutine(DestroyFireBall());
    }
    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other) // �������� � ������� ������ ��������(�� � ����� ������ ��� ����� �.�. ������� � layer Enemy)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy is null)
        {
            Destroy(gameObject);
            return;
        }
        enemy.TakeDamage(_damage);
        //�������� �������� ����� �����
        //a������� ���������
        Destroy(gameObject);
    }

    private IEnumerator DestroyFireBall() // ����������� ������� ����� �����
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }
}
