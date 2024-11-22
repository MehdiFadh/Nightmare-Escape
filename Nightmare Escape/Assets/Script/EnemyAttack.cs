using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class EnemyAttack : MonoBehaviour
{
    private EnemyRef enemyReferences;
    private bool AttackCD;

    void Awake()
    {
        enemyReferences = GetComponent<EnemyRef>();
        StartCoroutine(AttackCoolDown());
    }

    private void OnTriggerStay(Collider target)
    {
        if(target.CompareTag("Player"))
        {
            if (AttackCD == true)
            {
                PlayerState.Instance.TakeDamage(EnemyState.Instance.attackDamage);
                AttackCD = false;
                StartCoroutine(AttackCoolDown());
            }

        }

    }

    private IEnumerator AttackCoolDown()
    {
        yield return new WaitForSeconds(1.2f);
        AttackCD = true;
    }
}
