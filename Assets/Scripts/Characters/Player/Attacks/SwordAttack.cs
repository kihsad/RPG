using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    [SerializeField]
    private MeleeAttack _meleeAtack;

    private void OnTriggerEnter(Collider other) // коллизии с разными видами обьектов(но в целом только для енеми т.к. рейкаст с layer Enemy)
    {
        var player = other.GetComponent<Player>();
        var enemy = other.GetComponent<Enemy>();

        if (player == null && enemy == null) return;

        if (enemy != null &&_meleeAtack.Character.gameObject.layer!=enemy.gameObject.layer&&_meleeAtack.Character.GetComponent<Player>().MyTarget==enemy.GetComponent<Character>().HitBox)
        {
            enemy.TakeDamage(_meleeAtack.GetDamage);
        }
        if (player != null )
        {
                player.TakeDamage(_meleeAtack.GetDamage);
        }
        //анимация полученя урона врага
        //aнимация попадания
    }
}
