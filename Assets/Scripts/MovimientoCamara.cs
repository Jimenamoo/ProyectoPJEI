using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject player; // Selecciona el objeto al que sigue la camas
    private Vector3 offset = new Vector3(0, 3, -7); // Desplazamiento de la camara respecto al player

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate() // Se ejecuta despues del Update
    {
        transform.position = player.transform.position + offset;
    }
}
