using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//cambio de escena

public class ChangeScene : MonoBehaviour
{
    public void ChangeLevel (string sceneName)//nos crea una variable con el nombre de la escena
    {
        SceneManager.LoadScene (sceneName);
    }
}
