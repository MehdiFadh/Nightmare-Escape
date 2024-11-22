using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBrain : MonoBehaviour
{
    public Transform target;
    private EnemyRef enemyReferences;
    private EnemyState EnemyState;
    private float attackDisatance;
    private float pathUpdateDeadline;
    private bool isInRange;
    public Animator animator;

    private void Awake()
    {
        enemyReferences = GetComponent<EnemyRef>();
        EnemyState = GetComponent<EnemyState>();
        target = EnemyManager.Instance.Player;
    }

    void Start()
    {
        attackDisatance = enemyReferences.navMeshagent.stoppingDistance;
        enemyReferences.navMeshagent.speed = 15f;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        
        if(target != null)
        {
            float inRange = Vector3.Distance(transform.position, target.position);
            if(inRange <= attackDisatance)
            {
                //enemyReferences.animator.SetBool("Move",false);
                isInRange = true;
            }
            else 
            {
                isInRange = false;
                //enemyReferences.animator.SetBool("Move",true);
            }

            if (isInRange || EnemyState.isStun || MenuManager.Instance.isMenuOpen)
            {
                LookAtTarget();
                animator.SetBool("death", true);
            }
            else
            {
                UpdatePath();
                animator.SetBool("death", true);
                
            }
            //enemyReferences.animator.SetBool("Hit", isInRange);
        }

        
    }

    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);
    }

    private void UpdatePath()
    {
        if (Time.time >= pathUpdateDeadline)
        {
            pathUpdateDeadline = Time.time + enemyReferences.pathUpdateDelay;
            enemyReferences.navMeshagent.SetDestination(target.position);
        }
        
    }
}
