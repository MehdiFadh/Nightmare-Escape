using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumiere : MonoBehaviour
{
    public Light lumiere;
    private bool allumer;
    // Start is called before the first frame update
    void Start()
    {
        lumiere = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if(allumer)
        {
            lumiere.range = 15f;
            StartCoroutine(Clignote());
        }
        else
        {
            lumiere.range = 5f;
            StartCoroutine(Clignote());
        }
        
    }

    IEnumerator Clignote()
    {
        yield return new WaitForSeconds(3f);
        if(allumer)
        {
            allumer = false;
        }
        else
        {
            allumer = true;
        }
        
    }
}
