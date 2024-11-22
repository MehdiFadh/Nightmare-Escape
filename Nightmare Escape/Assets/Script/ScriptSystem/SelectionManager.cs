using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance{get;set;}
    public bool onTarget;
    public GameObject selectedObject;

    public Image centerDotIcon;
    public Image handIcon;

    public bool handIsVisible;
    public bool Moteur;
    public bool essance;
    public bool pneu;
    public bool gun;
    public bool clef;
    public bool ClefForet;
    public bool PorteItem;
 
    private void Start()
    {
        onTarget = false;
        Moteur = false;
        essance = false;
        pneu = false;
    }

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
 
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;

            InteractibleObject interacteble = selectionTransform.GetComponent<InteractibleObject>();
 
            if (interacteble && interacteble.playerInRange)
            {
                onTarget = true;
                selectedObject = interacteble.gameObject;

                if(interacteble.CompareTag("pickable"))
                {
                    centerDotIcon.gameObject.SetActive(false);
                    handIcon.gameObject.SetActive(true);
                    handIsVisible = true;
                }
                else
                {
                    centerDotIcon.gameObject.SetActive(true);
                    handIcon.gameObject.SetActive(false);
                    handIsVisible = false;
                }
            }
            else 
            { 
                onTarget = false;
                centerDotIcon.gameObject.SetActive(true);
                handIcon.gameObject.SetActive(false);
                handIsVisible = false;
            }
 
        }
        else
        {
            onTarget = false;
            centerDotIcon.gameObject.SetActive(true);
            handIcon.gameObject.SetActive(false);
            handIsVisible = false;
        }
    }

    public void DisableSelection()
    {
        handIcon.enabled = false;
        centerDotIcon.enabled = false;

        selectedObject = null;

    }

    public void EnableSelection()
    {
        handIcon.enabled = true;
        centerDotIcon.enabled = true;
    }
}
