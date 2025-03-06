using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string dialogueMessage; // Mensaje único para cada objeto

    private GameObject player;
    private float interactionDistance = 2.0f;
    private bool hasInteracted = false; // Evita contar múltiples interacciones
    private InterfazMisiones missionManager; // Referencia al script de misiones

    void Start()
    {
        dialoguePanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
        missionManager = FindObjectOfType<InterfazMisiones>(); // Busca el script de misiones
    }

    void Update()
    {
        if (!hasInteracted && Vector3.Distance(player.transform.position, transform.position) < interactionDistance)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ShowDialogue();
                hasInteracted = true; // Marcar como interactuado
                missionManager.RegisterInteraction(); // Notificar la interacción
            }
        }
    }

    void ShowDialogue()
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = dialogueMessage;
        StartCoroutine(HideDialogueAfterTime(5f));
    }

    IEnumerator HideDialogueAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        dialoguePanel.SetActive(false);
    }
}
