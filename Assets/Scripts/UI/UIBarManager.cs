using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBarManager : MonoBehaviour
{
    [SerializeField]
    private Image[] _castBars;
    [SerializeField]
    private FireBall _fireBall;
    [SerializeField]
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            InventoryScript.Instance.OpenClose();
        }
    }
    public IEnumerator Progress(int index,float cd)
    {
        float rate = 1.0f / cd;
        float progress = 0f;
        while (progress <= 1)
        {
            _castBars[index].fillAmount = Mathf.Lerp(0, 1, progress);
            progress += rate * Time.deltaTime;

            yield return null;
        }
        _castBars[index].fillAmount = 0;
    }
}
