using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public CharacterController controller;//me permite coger el controlador del personaje
    //public AnimatorController Animator;//me permite coger las animaciones del personaje

    public float speed = 5f;//me permite ajustar la velocidad que va el personaje mientras avanza en una dirección

    public float Gravity = -9.81f;
    public Vector3 velocity;//permite coger la velocidad del jugador

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask floorMask;
    bool IsGrounded;

    public float turnSmoothTime = 0.1f;//Esto permite que al girar el personaje, haga un movimiento de giro fluido sin verse tosco o pixelado

    float turnSmoothVelocity;//Esto permite que el movimiento del personaje, se mueva más lento 

    public Transform cam;//Esto permitira coger la camara del personaje en tercera persona

    
    private void Start()
    {
        CharacterController controller = GetComponent<CharacterController>();
        //AnimatorController animator = GetComponent<AnimatorController>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");//Esto permitira coger los controles horinzontales a y d del teclado. Ojo poner el parentesis, las comillas y la primera letra en mayuscula, que si no lo pones, el personaje no se movera.
        float vertical = Input.GetAxisRaw("Vertical");//Esto permitira coger los controles horinzontales w y s del teclado. Ojo poner el parentesis, las comillas y la primera letra en mayuscula, que si no lo pones, el personaje no se movera.

        Vector3 direction = new Vector3(horizontal,0f, vertical).normalized;//Esto permite que el objecto se mueva en una direccion nueva en los ejes x e Z. La y los dejamos en cero para que el muñeco no suba arriba.

        //float fire2 = Input.GetAxisRaw("Fire2");//Con esto permitiria golpear al enemigo

        //float fire3 = Input.GetAxisRaw("Fire3");//Con esto permitira golpear más fuerte

        //float fire1 = Input.GetAxisRaw("Fire1");//Esto permitira bloquear el ataque del enemigo
    

        if (direction.magnitude >= 0.1f)//Esto permite que gire más fluido mayor que 0.1. Si es menor que 0.1, el movimiento de girar se vera más pixelado.
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;//Permite calcular el movimiento del personaje mientras el jugador lo mueve

            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y,targetAngle, ref turnSmoothVelocity, turnSmoothTime);//Permite calcular la fluidez del giro del personaje

            Vector3 movDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f,angle,0f);
 
            controller.Move(movDir.normalized*speed*Time.deltaTime);//Esto permite mover al personaje rapido o lento
        }


        IsGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, floorMask);


        velocity.y += Gravity * Time.deltaTime;
        if (IsGrounded && velocity.y < 0)
        {
            velocity.y = -9.81f;
        }

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && IsGrounded)
        {
            velocity.y = Mathf.Sqrt(3 * -2 * Gravity);
        }

    }

}
