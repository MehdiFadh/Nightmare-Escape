using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform Player;

    public static EnemyManager Instance {get; set;}

    private void Awake()
    {
        

       if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        } 
    }

}
