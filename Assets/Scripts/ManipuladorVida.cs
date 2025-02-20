using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManipuladorVida : MonoBehaviour
{
    VidaEnemigo enemigoVida;

    public int cantidad;        
    public float damageTime;    
    private float currentDamageTime = 0.0f;

 

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        enemigoVida = GameObject.FindWithTag("Enemigo").GetComponent<VidaEnemigo>();
    }

   
 


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemigo")
        {
            currentDamageTime += Time.deltaTime;

            if (currentDamageTime > damageTime)
            {
                enemigoVida.vida += cantidad;
                currentDamageTime = 0.0f;
            }
        }
    }
}
