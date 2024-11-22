using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISystem : MonoBehaviour
{
    public static UISystem Instance{get;set;}
    public GameObject StaminaBar;
    public GameObject playerState;
    public GameObject Page;
    public GameObject Mission;
    public GameObject TextTuto;
    public GameObject TextTuto2;
    public GameObject TextTuto3;
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

    // Update is called once per frame
    void Update()
    {
        if(playerState.GetComponent<PlayerState>().isRunning)
        {
            StaminaBar.SetActive(true);

        }

        if(!playerState.GetComponent<PlayerState>().isRunning && playerState.GetComponent<PlayerState>().currentStamina == playerState.GetComponent<PlayerState>().maxStamina)
        {
            StaminaBar.SetActive(false);
        }
    }
}
