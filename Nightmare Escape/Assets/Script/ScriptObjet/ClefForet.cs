using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClefForet : MonoBehaviour
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
        if(InteractibleObject.Interagie && !SelectionManager.Instance.PorteItem)
        {
            SelectionManager.Instance.ClefForet = true;
            SelectionManager.Instance.PorteItem = true;
            Destroy(this.gameObject);
        }
        
    }
}
