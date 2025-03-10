using System.Collections;
using System.Collections.Generic;
using TMPro; // Importar TextMeshPro
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText; // Usar TMP_Text en lugar de Text

    private Queue<string> sentences; // Cola para almacenar los diálogos
    private bool isDialogueActive = false; // Verifica si el diálogo está activo

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false);

        {
            if (dialogueText == null)
                Debug.LogError("Dialogue Text no está asignado en el Inspector.");

            if (dialoguePanel == null)
                Debug.LogError("Dialogue Panel no está asignado en el Inspector.");

            if (sentences == null)
                Debug.LogError("La cola de frases (sentences) no está inicializada.");
        }

    }

    void Update()
    {
        // Detectar si el jugador presiona la tecla "E" cuando hay diálogo activo
        if (isDialogueActive && Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue(string[] dialogue)
    {
        dialoguePanel.SetActive(true);
        sentences.Clear();
        isDialogueActive = true; // Activa el estado del diálogo

        foreach (string sentence in dialogue)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        isDialogueActive = false; // Desactiva el estado del diálogo
    }
}
