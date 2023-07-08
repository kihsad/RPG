using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandLocationScript : MonoBehaviour
{
    [SerializeField]
    private Collider _tpCollider;
    [SerializeField]
    private Citizen _citizen;
    private static SandLocationScript instance;
    public static SandLocationScript Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SandLocationScript>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        _tpCollider.isTrigger = false;
    }

    public void OnComplete()
    {
        _tpCollider.isTrigger = true;
    }
}
