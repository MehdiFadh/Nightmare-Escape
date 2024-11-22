using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soin : MonoBehaviour
{
    private InteractibleObject InteractibleObject;
    private bool soinFull;
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
            soinFull = EquipSystem.Instance.AddSoin();
            if(soinFull)
            {
                Destroy(this.gameObject);
            }
        }
        
    }
}
