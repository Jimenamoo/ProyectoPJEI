using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{

    public float speed = 5f; // Velocidad del jugador
    public float minX = -1f; // L�mite izquierdo en X
    public float maxX = 1f;  // L�mite derecho en X
    public float minZ =-1f; // L�mite inferior en Z
    public float maxZ = 1f;  // L�mite superior en Z


    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        // Movimiento del jugador
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * speed * Time.deltaTime;
        transform.Translate(movement);
    }
        
}
