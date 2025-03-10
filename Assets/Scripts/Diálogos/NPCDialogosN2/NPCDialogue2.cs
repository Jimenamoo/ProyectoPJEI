using UnityEngine;

public class NPCDialogue2 : MonoBehaviour
{
    public string[] dialogueLines; // Frases del NPC
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DialogueManager2 dialogueManager = FindObjectOfType<DialogueManager2>();

            if (!dialogueManager.IsDialogueActive()) // Si el di?logo no est? activo, lo inicia
            {
                dialogueManager.StartDialogue(dialogueLines);
            }
            else // Si ya est? activo, avanza en la conversaci?n
            {
                dialogueManager.DisplayNextSentence();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}
