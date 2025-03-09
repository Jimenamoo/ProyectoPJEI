using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager2 : MonoBehaviour
{
    public GameObject dialoguePanel; // Panel de diálogo en la UI
    public TMP_Text dialogueText; // Texto donde se mostrarán los diálogos

    private Queue<string> sentences; // Cola de frases
    private bool isDialogueActive = false; // Indica si el diálogo está activo

    void Start()
    {
        sentences = new Queue<string>();
        dialoguePanel.SetActive(false); // Oculta el panel al iniciar
    }

    public void StartDialogue(string[] dialogue)
    {
        dialoguePanel.SetActive(true);
        sentences.Clear();
        isDialogueActive = true;

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
        isDialogueActive = false;
    }

    public bool IsDialogueActive()
    {
        return isDialogueActive;
    }
}
