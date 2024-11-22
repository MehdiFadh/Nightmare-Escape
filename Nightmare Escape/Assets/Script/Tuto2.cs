using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto2 : MonoBehaviour
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
        UISystem.Instance.TextTuto2.SetActive(true);
    }

        private void OnTriggerExit(Collider other)
    {
        UISystem.Instance.TextTuto2.SetActive(false);
    }


}