using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{
   public static PlayerState Instance {get; set;}

    public float currentHealth;
    public float attackDamage;
    public float maxHealth;
    public float maxStamina;
    public float currentStamina;
    public GameObject PlayerBody;
    public bool isInCombat;
    public bool CDRegenStam;
    public bool isRunning;
    public GameObject Lamp;
    public bool AsLamp;
    public Animator animator;

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
        attackDamage = 10f;
        currentHealth = maxHealth;
        currentStamina = maxStamina;
        AsLamp = true;
    }

    private void Update()
    {

    }


    
    public void setHealth(float newHealth)
    {
        currentHealth = newHealth;
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        isInCombat = true;
        StartCoroutine(endOfCombat());


        if (currentHealth <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Mort");
        }
    }

    
    IEnumerator endOfCombat()
    {
        yield return new WaitForSeconds(10f);
        isInCombat = false;
    }
    

}
