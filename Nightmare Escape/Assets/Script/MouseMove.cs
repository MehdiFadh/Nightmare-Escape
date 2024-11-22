using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{
   public float mouseSensi = 125f;

    float xRotation = 0f;
    float YRotation = 0f;

    public GameObject playerCamera;
    
    void Start()
    {
        //lock cuseur et le rend invisible
        Cursor.lockState = CursorLockMode.Locked;
        playerCamera = GameObject.Find("Main Camera");

    }

    
    void Update()
    {
    
        float mouseX = Input.GetAxis("Mouse X") * mouseSensi * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensi * Time.deltaTime;

        // up down
        xRotation -= mouseY;

        // clamp pour pas pouvir trop tourner comme dans la vie
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        YRotation += mouseX;

        // aplication des rota
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, YRotation, 0f);
        
    }
}
