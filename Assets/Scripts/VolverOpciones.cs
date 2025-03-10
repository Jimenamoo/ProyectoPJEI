using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para gestionar las escenas

public class VolverOpciones : MonoBehaviour
{
    // Nombre de la escena a la que quieres cambiar al presionar ESC
    public string sceneToLoad;

    void Update()
    {
        // Detectar si la tecla ESC ha sido presionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Cambiar de escena
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        // Comprobar que el nombre de la escena no esté vacío
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            // Cambiar a la escena especificada
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("El nombre de la escena no ha sido especificado.");
        }
    }
}

