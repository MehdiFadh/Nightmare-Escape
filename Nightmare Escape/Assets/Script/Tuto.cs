using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        UISystem.Instance.TextTuto.SetActive(true);
    }

        private void OnTriggerExit(Collider other)
    {
        UISystem.Instance.TextTuto.SetActive(false);
    }


}
