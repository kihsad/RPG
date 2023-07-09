using System.Collections;
using UnityEngine;

public class MeleeAttackComponent : MonoBehaviour // ��������� ��� ���� ����� ����
{
    [SerializeField]
    private LayerMask _isEnemy;
    [SerializeField]
    private MeleeAttack _meleeAttack;
    [SerializeField]
    private SwordAttack _sword;

    private UIBarManager _spellManager;

    private float _speed;
    private bool _isCd;
    private bool isStarted;


    private void Awake()
    {
        _sword.gameObject.GetComponent<Collider>().enabled = false;
        _spellManager = FindObjectOfType<UIBarManager>();
        _meleeAttack = GetComponent<MeleeAttack>();
        _speed = Player.MyInstance.GetAgent.speed;

    }
    public void Attacking()
    {
        if(Input.GetMouseButtonDown(0)&&!_isCd) // ������� ���
        {
            Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(agentRay, out hitInfo, 100, _isEnemy))
            {
                if(!isStarted)
                StartCoroutine(MeleeAttackCooldown());
            }
        }
    }

    public IEnumerator MeleeAttackCooldown() // �� �����
    {
        isStarted = true;
            while (Player.MyInstance.MyTarget != null)
            {
                Player.MyInstance.GetAgent.SetDestination(Player.MyInstance.MyTarget.position);
                var distance = Vector3.Distance(transform.position, Player.MyInstance.MyTarget.position);
                if (distance <= _meleeAttack.AttackRange)
                {
                _isCd = true;
                transform.GetComponent<Animator>().SetBool("isMoving", false);
                Player.MyInstance.GetAgent.speed = 0;
                transform.LookAt(Player.MyInstance.MyTarget);
                _sword.gameObject.GetComponent<Collider>().enabled = true;
                transform.GetComponent<Animator>().Play("MeleeAttack_OneHanded");
                yield return new WaitForSeconds(0.25f);
                _sword.gameObject.GetComponent<Collider>().enabled = false;
                Player.MyInstance.GetAgent.speed = _speed;

                StartCoroutine(_spellManager.Progress(0, _meleeAttack.SwordCooldown)); // ��� ��������� �� �� ui
                yield return new WaitForSeconds(_meleeAttack.SwordCooldown);
                _isCd = false;
            }
            isStarted = false;
            yield return null;
        }
    }
}