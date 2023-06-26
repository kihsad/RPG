using UnityEngine;

public class SwordAttack : MonoBehaviour
{
    private Player _player;

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }
    private void OnTriggerEnter(Collider other) // коллизии с разными видами обьектов(но в целом только для енеми т.к. рейкаст с layer Enemy)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy is null)
        {
            return;
        }
        enemy.TakeDamage(_player.GetComponent<MeleeAttack>().GetDamage);
        //анимация полученя урона врага
        //aнимация попадания
    }
}
