using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public string thisName;
    public bool isConsumable;
 
    public float healthEffect;

    public bool isEquippable;
    public bool isNowEquipped;
    public bool isSelected;
   
    void Start()
    {
        
    }

    void Update ()
    {
    }




    public static void healthEffectCalculation(float healthEffect)
    {
 
        float healthBeforeConsumption = PlayerState.Instance.currentHealth;
        float maxHealth = PlayerState.Instance.maxHealth;
 
        if (healthEffect != 0)
        {
            if ((healthBeforeConsumption + healthEffect) > maxHealth)
            {
                PlayerState.Instance.setHealth(maxHealth);
            }
            else
            {
                PlayerState.Instance.setHealth(healthBeforeConsumption + healthEffect);
            }
        }
    }
}
