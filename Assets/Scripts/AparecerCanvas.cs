using UnityEngine;
using System.Collections;

public class CanvasManager : MonoBehaviour
{
    public Canvas canvas; // Referencia al Canvas

    void Start()
    {
        // Asegurar que el Canvas esté activo al entrar en la escena
        canvas.gameObject.SetActive(true);

        // Llamar a la corrutina para ocultarlo después de 2 segundos
        StartCoroutine(DesactivarCanvas());
    }

    IEnumerator DesactivarCanvas()
    {
        yield return new WaitForSeconds(1f); // Espera 2 segundos
        canvas.gameObject.SetActive(false); // Desactiva el Canvas
    }
}

