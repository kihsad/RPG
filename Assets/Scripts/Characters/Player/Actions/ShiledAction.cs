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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !_isCD)
        {
            StartCoroutine(ShieldCooldown());
        }
    }

    public IEnumerator ShieldCooldown() // κδ ροελλΰ
    {
        _isCD = true;
        _player.GetComponent<Collider>().enabled = false;
        StartCoroutine(_cooldownManager.Progress(1, _coolDown));
        yield return new WaitForSeconds(_immortalTime);
        _player.GetComponent<Collider>().enabled = true;
        yield return new WaitForSeconds(_coolDown-_immortalTime);
        _isCD = false;
    }
}
