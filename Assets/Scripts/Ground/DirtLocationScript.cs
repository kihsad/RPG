using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtLocationScript : MonoBehaviour
{
    [SerializeField]
    private Transform _goblinStackParent;
    [SerializeField]
    private Collider _prison;
    [SerializeField]
    private GameObject _bearButton;

    private static DirtLocationScript instance;
    public static DirtLocationScript Insance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<DirtLocationScript>();
            }
            return instance;
         }
    }

    private void Awake()
    {
        _bearButton.SetActive(false);
        _prison.enabled = false;
    }

    public bool IsComplete
    {
        get
        {
            return _goblinStackParent.childCount <= 0;
        }
    }
    private void Update()
    {
            OnCompleteBearQuest();
    }

    private void OnCompleteBearQuest()
    {
        if (IsComplete)
        {
            _prison.enabled = true;
            _bearButton.SetActive(true);
        }
    }

}
