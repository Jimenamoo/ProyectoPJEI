using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovimientoJugador : MonoBehaviour
{
    public float velocidad = 5f;  // Velocidad del movimiento

    private Rigidbody rb;

    void Start()
    {
        // Obtener el componente Rigidbody del jugador
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Obtener el movimiento horizontal y vertical de las flechas
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoZ = Input.GetAxis("Vertical");

        // Crear un vector para el movimiento
        Vector3 movimiento = new Vector3(movimientoX, 0f, movimientoZ) * velocidad * Time.deltaTime;

        // Aplicar el movimiento al Rigidbody
        rb.MovePosition(transform.position + movimiento);
    }
}

