using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public string[] dialogueLines; // L�neas de di�logo del NPC
    private bool playerInRange = false;

    void Update()
    {
        // Si el jugador est� cerca y presiona "E", inicia el di�logo
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueLines);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // Detecta que el jugador est� cerca
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false; // El jugador se aleja y ya no puede hablar
        }
    }
}
