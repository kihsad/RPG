using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIBarManager : MonoBehaviour
{
    [SerializeField]
    private Image[] _castBars;
    [SerializeField]
    private FireBall _fireBall;

    private static UIBarManager instance;

    public static UIBarManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<UIBarManager>();
            }
            return instance;
        }
    }


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

    public void UpdateStackSize(IClickable clickable)
    {
        if (clickable.MyCount > 1)
        {
            clickable.MyStackText.text = clickable.MyCount.ToString();
            clickable.MyStackText.color = Color.white;
            clickable.MyIcon.color = Color.white;
        }
        else
        {
            clickable.MyStackText.color = new Color(0, 0, 0, 0);
            clickable.MyIcon.color = Color.white;
        }

        if (clickable.MyCount == 0)
        {
            clickable.MyIcon.color = new Color(0, 0, 0, 0);
            clickable.MyStackText.color = new Color(0, 0, 0, 0);
        }
    }
}
