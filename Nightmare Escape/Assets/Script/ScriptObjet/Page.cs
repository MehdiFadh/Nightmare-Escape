using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Page : MonoBehaviour
{
    private InteractibleObject InteractibleObject;
    private bool pageActif;
    // Start is called before the first frame update
    void Start()
    {
        InteractibleObject = GetComponent<InteractibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InteractibleObject.Interagie && !pageActif)
        {
            UISystem.Instance.Page.SetActive(true);
            pageActif = true;
        }
        
        if(pageActif && Input.GetKeyDown(KeyCode.E))
        {
            UISystem.Instance.Page.SetActive(false);
            pageActif = false;

        }
        
    }
}
