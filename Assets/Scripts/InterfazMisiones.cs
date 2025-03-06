using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class InterfazMisiones : MonoBehaviour
{
    public GameObject missionPanel; // Panel de la ventana emergente
    public TMP_Text missionText;
    public string firstMission = "MISIÓN 1: Lávate la cara y cámbiate de ropa";
    public string secondMission = "MISIÓN 2: Sal de la habitación para explorar";

    private List<DialogueManager> interactuableObjects = new List<DialogueManager>(); // Lista de objetos interactuables
    private int interactions = 0; // Contador de interacciones
    private bool firstMissionCompleted = false;

    public ChangeScenePuerta changeSceneScript; // Referencia al script ChangeScenePuerta

    void Start()
    {
        // Encuentra todos los objetos con el script DialogueManager y los añade a la lista
        interactuableObjects.AddRange(FindObjectsOfType<DialogueManager>());
        StartCoroutine(ActivatePanelAndTextAfterDelay());
    }

    private IEnumerator ActivatePanelAndTextAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        missionPanel.SetActive(true);
        missionText.text = firstMission;
        missionText.ForceMeshUpdate();
    }

    public void RegisterInteraction()
    {
        if (!firstMissionCompleted)
        {
            interactions++;
            if (interactions >= interactuableObjects.Count) // Si interactuaste con todos los objetos
            {
                firstMissionCompleted = true;
                missionText.text = secondMission;
                missionText.ForceMeshUpdate();

                // Activar el cambio de escena solo después de completar las interacciones
                changeSceneScript.EnableSceneChange(true); // Habilitar el cambio de escena
            }
        }
    }
}


