using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int _value;

    public int Value
    {
        get => _value;
        set
        {
            _value = Mathf.Clamp(value, 0, 50);
            if (_value <= 0)
            {
                Destroy(gameObject);


            }
        }
    }

    public void TakeDamage(int damage)
    {
        Value -= damage;

        Debug.Log(Value + name);
    }

    public void Die()
    {
        Value = 0;
    }
}
