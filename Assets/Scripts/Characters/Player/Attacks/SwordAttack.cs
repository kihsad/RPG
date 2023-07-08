using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField]
    private MeleeAttack _meleeAtack;

    private void OnTriggerEnter(Collider other) // �������� � ������� ������ ��������(�� � ����� ������ ��� ����� �.�. ������� � layer Enemy)
    {
        var player = other.GetComponent<Player>();
        var enemy = other.GetComponent<Enemy>();

        if (player == null && enemy == null) return;

            if (enemy != null && enemy.IsAlive && _meleeAtack.Character.gameObject.layer != enemy.gameObject.layer && _meleeAtack.Character.GetComponent<Player>().MyTarget == enemy.GetComponent<Character>().HitBox)
            {
                enemy.TakeDamage(_meleeAtack.MyDamage);
            SoundManager.Instance.PlaySound(enemy.GetComponent<EnemyController>().attackSound);
        }
        else if (enemy != null && enemy.IsAlive && _meleeAtack.Character.gameObject.layer != enemy.gameObject.layer)
        {
            enemy.TakeDamage(_meleeAtack.MyDamage);
            SoundManager.Instance.PlaySound(enemy.GetComponent<EnemyController>().attackSound);
        }

        if (player != null )
        {
                player.TakeDamage(_meleeAtack.MyDamage);
        }
    }
}
