using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatTextManager : MonoBehaviour
{
    private static CombatTextManager instance;
    public static CombatTextManager Instance
    {
        get
        {
            if(instance==null)
            {
                instance = FindObjectOfType<CombatTextManager>();
            }
            return instance;
        }
    }

    [SerializeField]
    private GameObject _prefabCT;

    public void CreateText(Vector3 posisiton , string text,SCtype type)
    {
        Text sct = Instantiate(_prefabCT, transform).GetComponent<Text>();
        sct.transform.position = posisiton;
        string operation = string.Empty;

        switch (type)
        {
            case SCtype.Damage:
                operation = "-";
                sct.color = Color.red;
                break;
            case SCtype.Heal:
                operation = "+";
                sct.color = Color.green;
                break;
        }
        sct.text = operation + text;
    }
}

public enum SCtype
{
    Damage,
    Heal
}
