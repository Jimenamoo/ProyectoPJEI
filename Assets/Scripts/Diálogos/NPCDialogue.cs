using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public string[] dialogueLines; // Líneas de diálogo del NPC
    private bool playerInRange = false;

    void Update()
    {
        // Si el jugador está cerca y presiona "E", inicia el diálogo
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogueLines);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true; // Detecta que el jugador está cerca
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
