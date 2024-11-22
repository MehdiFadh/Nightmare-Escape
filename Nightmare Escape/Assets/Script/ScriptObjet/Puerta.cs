using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public Animator animator;
    private InteractibleObject InteractibleObject;
    private bool estOuverte;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        InteractibleObject = GetComponent<InteractibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InteractibleObject.Interagie && !estOuverte)
        {
            animator.SetBool("Ouverture", true);
            estOuverte = true;
        }
        else if(InteractibleObject.Interagie && estOuverte)
        {
            animator.SetBool("Ouverture", false);
            estOuverte = false;
        }
    }
}
