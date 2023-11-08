using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public bool isCheckpointReached = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica si el jugador ha tocado el checkpoint
        if (other.CompareTag("Player"))
        {
            isCheckpointReached = true;

            Debug.Log("Checkpoint reached!");
        }
    }
   
}
