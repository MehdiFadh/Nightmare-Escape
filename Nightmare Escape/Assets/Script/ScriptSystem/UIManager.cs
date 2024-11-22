using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance {get;set;}
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

    public GameObject Texte;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
