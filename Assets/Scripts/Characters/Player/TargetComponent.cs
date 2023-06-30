using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetComponent : MonoBehaviour
{
    [SerializeField]
    private Player _player;
    private NPC _currentTarget;
    [SerializeField]
    private LayerMask _npc;


    private void Update()
    {
        ClickTarget();
    }

    private void ClickTarget()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(agentRay, out hitInfo, 100, _npc))
            {
                if (_currentTarget != null)
                {
                    _currentTarget.DeSelect();
                }
                _currentTarget = hitInfo.collider.GetComponent<Enemy>();
                _player.MyTarget = _currentTarget.Select();
                Debug.Log(_player.MyTarget);
            }
            else
            {
                if (_currentTarget != null)
                {
                    _currentTarget.DeSelect();
                }

                _currentTarget = null;
                _player.MyTarget = null;
            }
        }
    }
}
