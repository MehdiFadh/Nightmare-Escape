using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipableItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        string selectItemName = EquipSystem.Instance.selectedItem.name.Replace("(Clone)", "");
        if(selectItemName == "Soin")
        {
            float healthBeforeConsumption = PlayerState.Instance.currentHealth;
            float maxHealth = PlayerState.Instance.maxHealth;
    
            if(Input.GetMouseButtonDown(0) && int.Parse(EquipSystem.Instance.numberOfSoin.text) >= 1)
            {
                if ((healthBeforeConsumption + 20) > maxHealth)
                {
                    PlayerState.Instance.setHealth(maxHealth);
                }
                else
                {
                    PlayerState.Instance.setHealth(healthBeforeConsumption + 20);
                    EquipSystem.Instance.numberOfSoin.text = $"{int.Parse(EquipSystem.Instance.numberOfSoin.text)-1}";
                }
            }
            
            
        }
        else
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selectionTransform = hit.transform;
                if(selectionTransform.CompareTag("Enemy"))
                {
                    EnemyState EnemyState = selectionTransform.GetComponent<EnemyState>();
                    if(Input.GetMouseButtonDown(0))
                    {
                        EnemyState.TakeDamage(10f);
                    }
                }
            }
        }
    }


}
