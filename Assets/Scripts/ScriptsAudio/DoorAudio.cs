using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAudio : MonoBehaviour
{
    public AudioSource doorSource;
    public AudioClip doorClip;
    public bool canOpen = false; // Se cambia a true cuando el jugador cumple los requisitos
    public float interactionRange = 5f; // Distancia máxima para interactuar con la puerta
    public Transform player; // Referencia al jugador

    void Update()
    {
        // Verifica si el jugador está dentro del rango y si los requisitos se han cumplido
        if (Vector3.Distance(player.position, transform.position) <= interactionRange && canOpen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                doorSource.clip = doorClip;
                doorSource.Play();
                OpenDoor();
            }
        }
    }

    void OpenDoor()
    {
        // Aquí puedes agregar la animación o el código para abrir la puerta
        Debug.Log("Puerta abierta.");
    }
}

