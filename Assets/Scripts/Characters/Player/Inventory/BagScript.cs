using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour
{

    [SerializeField]
    private GameObject _slotPrefab;

    public void AddSlots(int slotCount)
    {
        for(int i=0;i<slotCount;i++)
        {
            Instantiate(_slotPrefab, transform);
        }
    }
}
