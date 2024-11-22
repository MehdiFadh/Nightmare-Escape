using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public float currentHealth;
    public float attackDamage;
    public float maxHealth;
    public bool isStun;
    public static EnemyState Instance {get; set;}
    

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

    private void Start()
    {
        attackDamage = 10;
        currentHealth = maxHealth;
        isStun = false;
    }

    public void setHealth(float newHealth)
    {
        currentHealth = newHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= 10;
        if (currentHealth <= 0)
        {
            isStun = true;
            
            StartCoroutine(MobStun());
        }
    }

    IEnumerator MobStun()
    {
        yield return new WaitForSeconds(10f);
        
        currentHealth = maxHealth;
        isStun = false;
    }

    
}
