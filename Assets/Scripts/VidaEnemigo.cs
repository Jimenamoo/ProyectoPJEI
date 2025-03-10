using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class VidaEnemigo : MonoBehaviour
{
    public float vida = 100;
    public Image barraDeVida;
    public string gameOverScene; // Nombre de la escena a cargar cuando la vida llega a 0

    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100); // Evita que la vida pase de los límites

        barraDeVida.fillAmount = vida / 100; // Controla el slider de la imagen

        if (vida <= 0)
        {
            CambiarEscena(); // Llama al método de cambio de escena
        }
    }

    void CambiarEscena()
    {
        if (!string.IsNullOrEmpty(gameOverScene))
        {
            SceneManager.LoadScene(gameOverScene); // Carga la escena de Game Over
        }
        else
        {
            Debug.LogError("No se ha asignado una escena para el Game Over.");
        }
    }
}

