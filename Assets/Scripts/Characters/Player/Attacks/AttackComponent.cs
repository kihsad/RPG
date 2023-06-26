using System.Collections;
using UnityEngine;

public class AttackComponent : MonoBehaviour // ��������� ��� ���� ����� ����
{
    [SerializeField]
    private LayerMask _isEnemy;
    [SerializeField]
    private FireBall _fireBall;
    [SerializeField]
    private FireballPlace _spellPlace;
    [SerializeField]
    private MeleeAttack _meleeAttack;
    [SerializeField]
    private SwordAttack _sword;
    private UIBarManager _spellManager;

    private bool _spellCD=false;
    private bool _meleeCD = false;

    private void Start()
    {
        _sword.gameObject.GetComponent<Collider>().enabled = false;
        _spellManager = FindObjectOfType<UIBarManager>();
        _meleeAttack = GetComponent<MeleeAttack>();

    }
    public void Attacking() // ����������� � ������ (���� - ������� ��� ,����� ���� ���������� ����� ������ ��������� - ��������� , ������ ,���������� ����� , ������ ������� ������)
    {
        if (Input.GetMouseButtonDown(1)&&_spellCD is false) // ������� ���
        {
            Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(agentRay, out hitInfo, 30, _isEnemy))
            {
                //�������� ��������� � ����� ������
                _fireBall.transform.position = _spellPlace.transform.position;
                _fireBall.transform.LookAt(hitInfo.point);
                transform.LookAt(hitInfo.point);
                StartCoroutine(SpellAttackCooldown());
            }
        }
        else
        if(Input.GetMouseButtonDown(0)&&_meleeCD is false) // ������� ���
        {
            Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(agentRay, out hitInfo, 50, _isEnemy))
            {
                var distance = Vector3.Distance(transform.position, hitInfo.point);
                if (distance <= _meleeAttack.GetAttackRange)
                {
                    _sword.gameObject.GetComponent<Collider>().enabled = true;
                    transform.GetComponent<Animator>().Play("MeleeAttack_OneHanded"); //�������� ����� ����� - �������� !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                    StartCoroutine(MeleeAttackCooldown());
                }
            }
        }

    }
    public IEnumerator SpellAttackCooldown() // �� ������
    {
        _spellCD = true;
        transform.GetComponent<Animator>().Play("SpellCast"); //a������� ����� ������ - �������� !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        yield return new WaitForSeconds(1.5f);
        Instantiate(_fireBall);
        StartCoroutine(_spellManager.Progress(1, _fireBall.GetCooldown)); // ��� ��������� �� �� ui
        yield return new WaitForSeconds(_fireBall.GetCooldown);
        _spellCD = false;
    }
    public IEnumerator MeleeAttackCooldown() // �� �����
    {
        yield return new WaitForSeconds(0.25f);
        _sword.gameObject.GetComponent<Collider>().enabled = false;
        _meleeCD = true;
        Debug.Log("Attack");
        StartCoroutine(_spellManager.Progress(0,_meleeAttack.GetCooldown)); // ��� ��������� �� �� ui
        yield return new WaitForSeconds(_meleeAttack.GetCooldown);
        _meleeCD = false;
    }
}
