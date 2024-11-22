using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Voiture : MonoBehaviour
{
    private InteractibleObject InteractibleObject;
    // Start is called before the first frame update
    void Start()
    {
        InteractibleObject = GetComponent<InteractibleObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if(InteractibleObject.Interagie)
        {
            if(SelectionManager.Instance.essance || SelectionManager.Instance.pneu || SelectionManager.Instance.Moteur || SelectionManager.Instance.ClefForet)
            {
                SelectionManager.Instance.PorteItem = false;
            }
            if(SelectionManager.Instance.essance && SelectionManager.Instance.pneu && SelectionManager.Instance.Moteur && SelectionManager.Instance.ClefForet)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                SceneManager.LoadScene("Fin");
            }
            else
            {

            }
        }
    }
}
