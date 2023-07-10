using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField]
    private MeleeAttack _meleeAtack;
    public AudioClip attackSound;
    private int _random;

    private void OnTriggerEnter(Collider other) // �������� � ������� ������ ��������(�� � ����� ������ ��� ����� �.�. ������� � layer Enemy)
    {
        var player = other.GetComponent<Player>();
        var enemy = other.GetComponent<Enemy>();

        if (player == null && enemy == null) return;

            if (enemy != null && enemy.IsAlive && _meleeAtack.Character.gameObject.layer != enemy.gameObject.layer && _meleeAtack.Character.GetComponent<Player>().MyTarget == enemy.GetComponent<Character>().HitBox)
            {
            _random = Random.Range(0, 100);
            if (enemy.MyHealth.MyCurrentValue >= enemy.MyHealth.MyMaxValue / 2)
            {
                enemy.TakeDamage(_meleeAtack.MyDamage);
                SoundManager.Instance.PlaySound(attackSound);
            } else if(_random>=20)
            {
                enemy.TakeDamage(_meleeAtack.MyDamage);
                SoundManager.Instance.PlaySound(attackSound);
            }
        }
        else if (enemy != null && enemy.IsAlive && _meleeAtack.Character.gameObject.layer != enemy.gameObject.layer&&_meleeAtack.GetComponent<BearController>()!=null)
        {
            enemy.TakeDamage(_meleeAtack.MyDamage);
        }

        if (player != null )
        {
                player.TakeDamage(_meleeAtack.MyDamage);
            SoundManager.Instance.PlaySound(_meleeAtack.GetComponent<EnemyController>().attackSound);
        }
    }
}
