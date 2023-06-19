using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    public Transform _sword;

    public float _attackRange = 10f;


    public LayerMask _enemyLayer;

    public int Damage { get; set; }

    public void Attack()
    {
        Collider[] hitEnemies = Physics.OverlapSphere(_sword.position, _attackRange, _enemyLayer);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(Damage);
            Debug.Log(Damage);
        }
    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(_sword.position, _attackRange);
    }
}
