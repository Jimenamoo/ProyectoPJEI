using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;//me permite coger el controlador del personaje 
    Animator anim;

    Vector2 movement;
    public float walkSpeed;
    public float sprintSpeed;
    bool sprinting;
    float trueSpeed;

    private Vector3 velocity;//permite coger la velocidad del jugador

    public float jumpHeight;
    public float gravity;
    bool isGrounded;

    float turnSmoothTime = 0.1f;//Esto permite que al girar el personaje, haga un movimiento de giro fluido sin verse tosco o pixelado

    float turnSmoothVelocity;//Esto permite que el movimiento del personaje, se mueva más lento 

    public Transform cam;//Esto permitira coger la camara del personaje en tercera persona

    private void Start()
    {
        trueSpeed = walkSpeed;       
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
       
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, 1);
        anim.SetBool("IsGrounded", isGrounded);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            trueSpeed = sprintSpeed;
            sprinting = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            trueSpeed = walkSpeed;
            sprinting = false;
        }


        anim.transform.localPosition = Vector3.zero;
        anim.transform.localEulerAngles = Vector3.zero;
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector3 direction = new Vector3(movement.x ,0f, movement.y).normalized;//Esto permite que el objecto se mueva en una direccion nueva en los ejes x e Z. La y los dejamos en cero para que el muñeco no suba arriba.


        if (direction.magnitude >= 0.1f)//Esto permite que gire más fluido mayor que 0.1. Si es menor que 0.1, el movimiento de girar se vera más pixelado.
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;//Permite calcular el movimiento del personaje mientras el jugador lo mueve

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);//Permite calcular la fluidez del giro del personaje

            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f,angle,0f);
 
            controller.Move(moveDirection.normalized * trueSpeed * Time.deltaTime);//Esto permite mover al personaje rapido o lento

            if (sprinting == true) 
            {
                anim.SetFloat("Speed", 2);
            }
            else
            {
                anim.SetFloat("Speed", 1);
            }
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt((jumpHeight * 10) * -2 * gravity);
        }

        if (velocity.y > -20)
        {
            velocity.y += (gravity * 10) * Time.deltaTime;
        }

        
        controller.Move(velocity * Time.deltaTime);

    }
}
