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
   // private MeleeAttack _meleeAttack;

    public IEnumerator Progress(int index,float cd)
    {
        float timeLeft = Time.deltaTime;
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
