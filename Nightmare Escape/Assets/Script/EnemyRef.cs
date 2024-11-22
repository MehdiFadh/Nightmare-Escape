using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[DisallowMultipleComponent]
public class EnemyRef : MonoBehaviour
{
    public NavMeshAgent navMeshagent;
    //public Animator animator;

    public float pathUpdateDelay = 0.2f;

    public void Awake()
    {
        navMeshagent = GetComponent<NavMeshAgent>();
        //animator = GetComponent<Animator>();
    }
}
