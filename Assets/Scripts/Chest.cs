using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{

    [SerializeField]
    private float _lifeTime;

    private void Update()
    {
        DestroyChest();
    }
    public void DestroyChest()
    {
        if(LootWindow.Instance.droppedLoot == null)
        {
            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DestroyCoroutine());
        }
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);
    }

}

