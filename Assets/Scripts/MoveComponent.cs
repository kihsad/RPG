using System.Collections;
using UnityEngine;

namespace RPGPlayer
{
    public class MoveComponent : MonoBehaviour
    {
        [SerializeField]
        private LayerMask _canBeClicked;

        private Player _player;

        private void Start()
        {
            _player = GetComponent<Player>();
        }

        public void Moving()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(agentRay, out hitInfo, 100, _canBeClicked))
                {
                    _player.GetAgent.SetDestination(hitInfo.point);
                }
            }
        }
      

    }
}
