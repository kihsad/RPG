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

        public void Raycast()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(agentRay, out hitInfo, 100, _canBeClicked))
                {
                    Debug.Log("hit");
                    transform.LookAt(hitInfo.point);
                    _player.GetAgent.SetDestination(hitInfo.point);
                }
            }
        }

    }
}
