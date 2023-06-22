using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour // ui статы персонажей
{
    [SerializeField]
    private Text _statValue;
    [SerializeField]
    private float _lerpSpeed;

    private Image _content;

    private float _currentFill;
    private float _currentValue;

    public float MyMaxValue { get; set; }

    public float MyCurrentValue
    {
        get
        {

            return _currentValue;
        }
        set
        {
            if (value > MyMaxValue)
            {
                _currentValue = MyMaxValue;
            }
            else if (value < 0)
            {
                _currentValue = 0;
            }
            else
            {
                _currentValue = value;
            }
            _currentFill = _currentValue / MyMaxValue;
            if (_statValue != null)
            {
                _statValue.text = _currentValue + " / " + MyMaxValue;
            }
        }
    }
    private void Start()
    {
        _content = GetComponent<Image>();
    }
    private void Update()
    {
        if(_currentFill!=_content.fillAmount)
        {
            _content.fillAmount = Mathf.Lerp(_content.fillAmount, _currentFill, Time.deltaTime*_lerpSpeed);
        }
        _content.fillAmount = _currentFill;
    }
    public void Initialize(float currentVal,float maxVal)
    {
        if(_content is null)
        {
            _content = GetComponent<Image>();
        }
        MyMaxValue = maxVal;
        MyCurrentValue = currentVal;
        _content.fillAmount = MyCurrentValue / MyMaxValue;
    }
}
