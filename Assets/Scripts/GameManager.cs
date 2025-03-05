using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no est� asignado.");
        }
    }
    public void QuitGame()
    {
        
        Application.Quit(); // Cierra la aplicaci�n
    }
    public string sceneName; // Nombre de la escena a la que cambiar

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Detecta si se presiona la tecla Escape
        {
            ChangeScene(); // Llama a la funci�n para cambiar de escena
        }
    }

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("El nombre de la escena no est� asignado.");
        }
    }

}

