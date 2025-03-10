using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource stepSource;
    public AudioClip stepClip;
    public AudioSource jumpSource;
    public AudioClip jumpClip;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Si está en movimiento, reproducir el sonido de los pasos
        if (IsMoving() && !stepSource.isPlaying)
        {
            stepSource.clip = stepClip;
            stepSource.Play();
        }
        // Si no está en movimiento, detener el sonido de los pasos
        else if (!IsMoving() && stepSource.isPlaying)
        {
            stepSource.Stop();
        }

        // Sonido de jadeo al saltar
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            jumpSource.clip = jumpClip;
            jumpSource.Play();
        }
    }

    bool IsMoving()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D) ||
               Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightArrow);
    }
}
