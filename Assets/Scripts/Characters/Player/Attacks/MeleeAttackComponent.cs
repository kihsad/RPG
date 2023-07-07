using System.Collections;
using UnityEngine;

public class MeleeAttackComponent : MonoBehaviour // компонент для двух видов атак
{
    [SerializeField]
    private LayerMask _isEnemy;
    [SerializeField]
    private MeleeAttack _meleeAttack;
    [SerializeField]
    private SwordAttack _sword;

    private UIBarManager _spellManager;

    private Transform _target;

    private bool _meleeCD = false;

    public AudioClip attackSound;

    private void Awake()
    {
        _sword.gameObject.GetComponent<Collider>().enabled = false;
        _spellManager = FindObjectOfType<UIBarManager>();
        _meleeAttack = GetComponent<MeleeAttack>();

    }
    public void Attacking()
    {
        if(Input.GetMouseButtonDown(0)&&_meleeCD is false) // ближний бой
        {
            Ray agentRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(agentRay, out hitInfo, 50, _isEnemy))
            {
                var distance = Vector3.Distance(transform.position, hitInfo.point);
                if (distance <= _meleeAttack.AttackRange)
                {
                    _target = hitInfo.transform;
                    _sword.gameObject.GetComponent<Collider>().enabled = true;
                    transform.GetComponent<Animator>().Play("MeleeAttack_OneHanded");
                    SoundManager.Instance.PlaySound(attackSound);
                    StartCoroutine(MeleeAttackCooldown());
                }
            }
        }
    }

    public IEnumerator MeleeAttackCooldown() // кд атаки
    {
        transform.LookAt(_target);
        yield return new WaitForSeconds(0.25f);
        _sword.gameObject.GetComponent<Collider>().enabled = false;
        _meleeCD = true;
        Debug.Log("Attack");
        StartCoroutine(_spellManager.Progress(0,_meleeAttack.SwordCooldown)); // для отрисовки кд на ui
        yield return new WaitForSeconds(_meleeAttack.SwordCooldown);
        _meleeCD = false;
    }
}
