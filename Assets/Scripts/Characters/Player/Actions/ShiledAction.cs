using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShiledAction : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    [SerializeField]
    private float _immortalTime;
    [SerializeField]
    private float _coolDown;
    [SerializeField]
    private UIBarManager _cooldownManager;
    private bool _isCD;

    public AudioClip shieldSound;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha2) && !_isCD)
        {
            SoundManager.Instance.PlaySound(shieldSound);
            StartCoroutine(ShieldCooldown());
        }
    }

    public IEnumerator ShieldCooldown() // κδ ροελλΰ
    {
        _isCD = true;
        _player.GetComponent<Collider>().enabled = false;
        StartCoroutine(_cooldownManager.Progress(2, _coolDown));
        yield return new WaitForSeconds(_immortalTime);
        _player.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(_coolDown-_immortalTime);
        _isCD = false;
    }
}
