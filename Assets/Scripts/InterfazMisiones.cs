using UnityEngine;
using TMPro;
using System.Collections; // Necesario para usar coroutines



public class InterfazMisiones : MonoBehaviour
{
    public GameObject missionPanel; // Panel de la ventana emergente
    public TMP_Text missionText;
    public GameObject player;
    public string firstMission = "MISIÓN 1:Lávate la cara y cámbiate de ropa"; // Texto de la primera misión
    public string secondMission = "Sal de la habitación para explorar";

    private int interactions = 0;
    private bool firstMissionCompleted = false;

    void Start()
    {
        // Iniciar la coroutine para mostrar el panel y el texto después de 3 segundos
        StartCoroutine(ActivatePanelAndTextAfterDelay());
    }

    // Coroutine que activa el panel y el texto después de 3 segundos
    private IEnumerator ActivatePanelAndTextAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Espera 3 segundos
        missionPanel.SetActive(true); // Activar el panel
        missionText.text = firstMission; // Establecer el texto de la misión
        missionText.ForceMeshUpdate(); // Actualizar el texto inmediatamente
    }

    public void RegisterInteraction()
    {
        if (!firstMissionCompleted)
        {
            interactions++;
            if (interactions >= 2)
            {
                firstMissionCompleted = true;
                missionText.text = secondMission;
            }
        }
    }
}




