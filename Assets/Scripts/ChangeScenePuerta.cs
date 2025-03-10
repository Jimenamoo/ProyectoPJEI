using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class ChangeScenePuerta : MonoBehaviour
{
    public string sceneToLoad; // El nombre de la escena a cargar
    private GameObject player;
    private float interactionDistance = 4.0f; // Distancia para detectar la interacción
    private bool canChangeScene = false; // Controla si el jugador puede cambiar de escena

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        // Verificar si el jugador está cerca del objeto y si se puede cambiar de escena
        if (canChangeScene && Vector3.Distance(player.transform.position, transform.position) < interactionDistance)
        {
            // Si presiona 'E', cambiar de escena
            if (Input.GetKeyDown(KeyCode.E))
            {
                ChangeToScene();
            }
        }
    }

    public void EnableSceneChange(bool enable)
    {
        canChangeScene = enable; // Activar o desactivar la capacidad de cambiar de escena
    }

    void ChangeToScene()
    {
        SceneManager.LoadScene(sceneToLoad); // Cambiar la escena
    }
}



