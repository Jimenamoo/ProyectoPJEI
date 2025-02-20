using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogos : MonoBehaviour
{
    public Transform player; // El personaje al que seguirá el diálogo
    public Vector3 offset;   // Distancia que tendrá el diálogo con respecto al personaje

    void Update()
    {
        // Actualiza la posición del diálogo para que siga al personaje
        transform.position = player.position + offset;

        // Si deseas que el diálogo siempre mire al personaje (opcional)
        transform.LookAt(player);
    }
}
