using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealAction : MonoBehaviour
{
    public IUseable MyUseable { get; set; }

    [SerializeField]
    private Item _healthPotion;
    [SerializeField]
    private float _healCooldown=0.5f;

    private bool _isCd = false;

    private Stack<IUseable> _useables;

    private void Update()
    {
        UsePotion();
    }
    public void UsePotion()
    {
        if (Input.GetKeyDown(KeyCode.R)&&!_isCd)
        {
            GetPotions(_healthPotion as IUseable);

            if (HandScript.Instance.MyMoveable == null)
            {
                if (_useables != null && _useables.Count > 0)
                {
                    StartCoroutine(PotionCD());
                }
            }
        }
    }

    public void GetPotions(IUseable useable)
    {
        if(useable is HealthsPotion)
        {
            _useables = InventoryScript.Instance.GetUseables(useable);
        }
       
        MyUseable = useable;
    }

    private IEnumerator PotionCD()
    {
        _isCd = true;
        StartCoroutine(UIBarManager.MyInstance.Progress(5, _healCooldown));
        _useables.Pop().Use();
        yield return new WaitForSeconds(_healCooldown);
        _isCd = false;
    }
}
