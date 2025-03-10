using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class SceneChanger : MonoBehaviour
{
    public string spaceSceneName; // Escena a cargar al presionar Space
    public string escapeSceneName; // Escena a cargar al presionar Esc

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Si se presiona SPACE
        {
            ChangeLevel(spaceSceneName);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) // Si se presiona ESC
        {
            ChangeLevel(escapeSceneName);
        }
    }

    public void OnMouseDown()
    {
        Debug.Log("Hago click"); // Mensaje en la consola
        ChangeLevel(spaceSceneName); // Cambia de escena al hacer clic
    }

    public void ChangeLevel(string sceneName) // Método para cambiar de escena
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



