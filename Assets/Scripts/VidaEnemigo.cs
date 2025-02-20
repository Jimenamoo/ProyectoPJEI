using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    public float vida = 100;

    public Image barraDeVida;
  

    // Update is called once per frame
    void Update()
    {
        vida = Mathf.Clamp(vida, 0, 100);//mathf.clamp hace que nuestra vida no exceda un max ni un min 

        barraDeVida.fillAmount = vida / 100;//controla el slider de la imagen
    }
}
