using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 9f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    
    public LayerMask groundMask;
    Animator animator;

    Vector3 velocity;
    
    bool isGrounded;
    bool lampActive;
    bool mission;

    private Vector3 lastPosition = new Vector3(0f,0f,0f);
    public bool isMoving;
    
    void Start()
    {
        lampActive = true;
        mission = false;
        animator = PlayerState.Instance.animator;
    }


    void Update()
    {
        //check hit ground pour reset falling velocity
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetKeyDown(KeyCode.Tab) && !mission)
        {
            UISystem.Instance.Mission.SetActive(true);
            mission = true;
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            UISystem.Instance.Mission.SetActive(false);
            mission = false;
        }

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        //check player on ground
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if(lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
            animator.SetBool("isWalking", true);
            //SoundManager.Instance.PlaySound(SoundManager.Instance.WalkSound);
        }
        else
        {
            animator.SetBool("isWalking", false);
            isMoving = false;
            //SoundManager.Instance.WalkSound.Stop();
        }
        lastPosition =gameObject.transform.position;
        

        if ( Input.GetKey("left shift") &&  PlayerState.Instance.currentStamina > 0)
        {
            speed = 15f;
            PlayerState.Instance.isRunning = true;
            PlayerState.Instance.currentStamina -= 10;
        }
        else
        {
            speed = 9f;
            PlayerState.Instance.isRunning = false;
            PlayerState.Instance.currentStamina += 1;
            
        }

        if(Input.GetKeyDown(KeyCode.F) && PlayerState.Instance.AsLamp && !lampActive)
        {
            PlayerState.Instance.Lamp.SetActive(true);
            lampActive = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && lampActive)
        {
            PlayerState.Instance.Lamp.SetActive(false);
            lampActive = false;
        }

        if(Input.GetKeyDown(KeyCode.Keypad3))
        {
            SelectionManager.Instance.ClefForet = true;
            SelectionManager.Instance.essance = true;
            SelectionManager.Instance.pneu = true;
            SelectionManager.Instance.Moteur = true;
        }

        if(Input.GetKeyDown(KeyCode.Keypad6))
        {
            SelectionManager.Instance.clef = true;
            SelectionManager.Instance.gun = true;
            PlayerState.Instance.AsLamp = true;
        }


    }

}
