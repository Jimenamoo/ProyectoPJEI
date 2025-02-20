using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public Transform player; // El personaje al que seguir� el di�logo
    public Vector3 offset;   // Distancia que tendr� el di�logo con respecto al personaje

    void Update()
    {
        // Actualiza la posici�n del di�logo para que siga al personaje
        transform.position = player.position + offset;

        // Si deseas que el di�logo siempre mire al personaje (opcional)
        transform.LookAt(player);
    }
}
