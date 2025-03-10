using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necesario para cambiar de escena

public class ManagerPuzzle : MonoBehaviour
{
    [Header("Referencias")]
    public RectTransform canvasRectTransform;
    public RectTransform[] puzzlePieces;

    [Header("Posiciones Correctas y Configuración")]
    public Vector2[] correctPositions;
    public float tolerance = 10f;
    public string nextSceneName = "NombreDeLaEscena"; // Cambia esto por el nombre de tu escena destino

    void Start()

    {

        
        {
            Cursor.lockState = CursorLockMode.None;  // Libera el cursor
            Cursor.visible = true;  // Hace que el cursor sea visible
        }


        // Obtener el tamaño del Canvas en píxeles
        Vector2 canvasSize = canvasRectTransform.sizeDelta;

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            RectTransform piece = puzzlePieces[i];

            float halfPieceWidth = piece.rect.width / 2f;
            float halfPieceHeight = piece.rect.height / 2f;

            float minX = -canvasSize.x / 2f + halfPieceWidth;
            float maxX = canvasSize.x / 2f - halfPieceWidth;
            float minY = -canvasSize.y / 2f + halfPieceHeight;
            float maxY = canvasSize.y / 2f - halfPieceHeight;

            float randomX, randomY;

            // Asegura que las piezas no caigan cerca de su posición correcta
            do
            {
                randomX = Random.Range(minX, maxX);
                randomY = Random.Range(minY, maxY);
            }
            while (Vector2.Distance(new Vector2(randomX, randomY), correctPositions[i]) < tolerance * 2);

            piece.anchoredPosition = new Vector2(randomX, randomY);
        }
    }

    void Update()
    {
        bool puzzleResuelto = true;

        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (Vector2.Distance(puzzlePieces[i].anchoredPosition, correctPositions[i]) > tolerance)
            {
                puzzleResuelto = false;
                break;
            }
        }

        if (puzzleResuelto)
        {
            Debug.Log("¡Puzzle completado!");
            CambiarEscena();
        }
    }

    void CambiarEscena()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
