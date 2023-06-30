using System.Collections.Generic;
using UnityEngine;

public class NPCDetector : MonoBehaviour // сфера для подсветки ui врагов
{
    private List<Enemy> _enemies;
    private void Start()
    {
        _enemies = new List<Enemy>();
    }
    private void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy == null) return;
        Debug.Log("enter");
        //enemy.Select();
        _enemies.Add(enemy);
    }
    private void OnTriggerExit(Collider other)
    {
        var enemy = other.GetComponent<Enemy>();
        if (enemy == null) return;
        Debug.Log("exit");
        enemy.DeSelect();
        _enemies.Remove(enemy);
    }
}
