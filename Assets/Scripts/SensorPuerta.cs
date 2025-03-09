using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Importante para usar TextMeshPro

public class SensorPuerta : MonoBehaviour
{
    public TMP_Text textoE; // Para usar con TextMeshPro
    private bool jugadorCerca = false;

    void Start()
    {
        if (textoE != null)
            textoE.gameObject.SetActive(false); // Ocultar el texto al inicio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            if (textoE != null)
            {
                textoE.text = "Pulsa E"; // Mostrar mensaje
                textoE.gameObject.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            if (textoE != null)
                textoE.gameObject.SetActive(false); // Ocultar mensaje
        }
    }

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("Puzzle"); // Cambiar de escena
        }
    }
}
