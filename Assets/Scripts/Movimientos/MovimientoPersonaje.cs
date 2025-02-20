using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{

    public float speed = 5f; // Velocidad del jugador
    public float minX = -1f; // Límite izquierdo en X
    public float maxX = 1f;  // Límite derecho en X
    public float minZ =-1f; // Límite inferior en Z
    public float maxZ = 1f;  // Límite superior en Z


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
