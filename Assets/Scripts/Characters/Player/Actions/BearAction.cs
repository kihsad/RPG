using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAction : MonoBehaviour
{
    [SerializeField]
    private GameObject _bear;
    [SerializeField]
    private float _coolDown;
    [SerializeField]
    private float _lifeTime;
    [SerializeField]
    private UIBarManager _uiBarManager;
    private bool _isCD;
    private Vector3 _offset;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            _offset = Vector3.forward*3f;
            StartCoroutine(BearSpawn());
        }
    }

    private IEnumerator BearSpawn()
    {
        _isCD = true;

        var go = Instantiate(_bear);
        go.GetComponent<MeleeAttack>().Character = GetComponent<Player>();
        _bear.transform.position = transform.position + _offset;
        StartCoroutine(_uiBarManager.Progress(4, _coolDown));
        yield return new WaitForSeconds(_lifeTime);
        Destroy(go);
        yield return new WaitForSeconds(_coolDown - _lifeTime);
        _isCD = false;
    }
}
