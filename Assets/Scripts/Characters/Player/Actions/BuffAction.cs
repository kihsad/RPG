using System.Collections;
using UnityEngine;

public class BuffAction : MonoBehaviour
{

    [SerializeField]
    private Player _player;
    [SerializeField]
    private float _coolDown;
    [SerializeField]
    private float _buffTime;
    [SerializeField]
    private UIBarManager _actionManager;
    [SerializeField]
    private MeleeAttack _sword;
    [SerializeField]
    private GameObject _buff;

    private float _damage=50;
    private bool _isCD;

    public AudioClip buffSound;

    private void Awake()
    {
        _buff.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3)&& !_isCD)
        {
            SoundManager.Instance.PlaySound(buffSound);
            StartCoroutine(BuffActionCorroutine());
        }
    }

    private IEnumerator BuffActionCorroutine()
    {
        _isCD = true;
        _sword.MyDamage += _damage;
        _buff.SetActive(true);
        StartCoroutine(_actionManager.Progress(3, _coolDown));
        yield return new WaitForSeconds(_buffTime);
        _buff.SetActive(false);
        _sword.MyDamage -= _damage;
        yield return new WaitForSeconds(_coolDown - _buffTime);
        _isCD = false;
    }
}
