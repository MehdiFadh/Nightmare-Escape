using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunItem : MonoBehaviour
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
            SelectionManager.Instance.gun = true;
            Destroy(this.gameObject);
            
        }
        
    }
}
