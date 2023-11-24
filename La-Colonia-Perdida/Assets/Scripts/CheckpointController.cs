using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public bool isCheckpointReached = false;
    public static int guardarKrill;
    public static int guardarVida;


    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el jugador ha tocado el checkpoint
        if (other.CompareTag("Player"))
        {
            isCheckpointReached = true;
            guardarKrill = MovimientoGuino.nKrill;
            guardarVida = MovimientoGuino.vida;
            Debug.Log(guardarVida);
            Debug.Log("Checkpoint reached!");
        }
    }

}