using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Cambio de escena

public class Space : MonoBehaviour
{
    public string sceneName; // Nombre de la escena a cargar

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Si se presiona la barra espaciadora
        {
            ChangeLevel(); // Cambia de escena
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Hago click"); // Mensaje en la consola
        ChangeLevel(); // Llama al cambio de escena
    }

    public void ChangeLevel() // Método para cambiar de escena
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no está asignado.");
        }
    }
}

