using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    public bool playerInRange;
    public bool Interagie;
    public string ItemName;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange && SelectionManager.Instance.onTarget && SelectionManager.Instance.selectedObject == gameObject)
        {
            Interagie = true;
        }
        else
        {
            Interagie = false;
        }
    }

    public string GetItemName()
    {
        return ItemName;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
         if(other.CompareTag("Player"))
        {
            playerInRange = false;
        }

    }
}
