using UnityEngine;
using UnityEngine.EventSystems;

public class LootComponent : MonoBehaviour
{
    [SerializeField]
    private LayerMask _interactable;
    [SerializeField]
    private float _lootableDistance=3f;
    private Vector3 _lootTarget; 

    private void Update()
    {
        OnClick();
        CloseLoot();
    }

    private void OnClick()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            
            Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(agentRay, out hitInfo, 100, _interactable))
            {
                var distance = Vector3.Distance(hitInfo.point, transform.position);
                if (distance < _lootableDistance)
                {
                    _lootTarget = hitInfo.point;
                    if(hitInfo.collider.GetComponent<QuestGiver>()!=null)
                    {
                        (hitInfo.collider.GetComponent<QuestGiver>() as NPC).Interact();
                    }
                    if (hitInfo.collider.GetComponent<LootTable>() != null)
                    {
                        hitInfo.collider.GetComponent<LootTable>().Interact();
                    }

                }
            }
        }
    }

    private void CloseLoot()
    {
        if (Vector3.Distance(transform.position, _lootTarget) > 3)
        {
            LootWindow.Instance.CloseLootWindow();
        }
    }
}
