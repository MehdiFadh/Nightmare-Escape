using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangementDeScène : MonoBehaviour
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
        if(InteractibleObject.Interagie && SelectionManager.Instance.clef && SelectionManager.Instance.gun && PlayerState.Instance.AsLamp)
        {
            SceneManager.LoadScene(2);
        }
        
    }
}
