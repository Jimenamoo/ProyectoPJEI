using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private Rigidbody rb;
    private bool isNearPlayer = false; // Indica si el jugador est� cerca
    private bool isPickedUp = false; // Indica si el objeto est� recogido

    [SerializeField]
    private Transform player; // Referencia al transform del jugador

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (player == null)
        {
            Debug.LogError("�Referencia al jugador no asignada! Arrastra el jugador al campo Player en el Inspector.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPlayer = true;
            Debug.Log("El jugador est� cerca del objeto.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isNearPlayer = false;
            Debug.Log("El jugador se ha alejado del objeto.");
        }
    }

    void Update()
    {
        if (isNearPlayer && Input.GetKeyDown(KeyCode.E))
        {
            if (isPickedUp)
            {
                Drop();
            }
            else
            {
                Pickup();
            }
        }
    }

    private void Pickup()
    {
        Debug.Log("Objeto recogido.");
        isPickedUp = true;
        rb.isKinematic = true; // Detiene las f�sicas del objeto
        GetComponent<Collider>().enabled = false; // Desactiva el collider f�sico
        transform.SetParent(player); // Adjunta el objeto al jugador
        transform.localPosition = new Vector3(0, 1, 0); // Ajusta la posici�n relativa al jugador
    }

    private void Drop()
    {
        Debug.Log("Objeto soltado.");
        isPickedUp = false;
        transform.SetParent(null); // Desvincula el objeto del jugador
        rb.isKinematic = false; // Reactiva las f�sicas
        GetComponent<Collider>().enabled = true; // Reactiva el collider f�sico
    }
}
