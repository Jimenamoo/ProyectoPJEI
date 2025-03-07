using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//cambio de escena 
using UnityEngine.UI;//libreria interface

public class ClicKObject : MonoBehaviour
{
    public string sceneName;//variable nombre escena
    public Canvas canvasSuporposicion;//el canvas que se activa/desactiva
    public void OnMouseDown()
    {
        Debug.Log("hago click");//escribe en consola eso
        ChangeLevel(); //llama al cambio de escena
    }//cuando haces clic...

    private void OnMouseOver()//detecta si estamos sobre el objeto y activa el canvas
    {
        ActivaSuporposicion();
    }

    private void OnMouseExit()//detecta si estamos sobre el objeto y activa el canvas
    {
        DesactivaSuporposicion();
    }
    public void ActivaSuporposicion()
    {
        canvasSuporposicion.gameObject.SetActive(true);//activa la superposici?n
    }



    public void DesactivaSuporposicion()
    {
        canvasSuporposicion.gameObject.SetActive(false);//activa la superposici?n
    }
    public void ChangeLevel()//nos crea una variable con el nombre de la escena
    {
        SceneManager.LoadScene(sceneName);
    }
}
