using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrelMovement : MonoBehaviour
{
    public float movementDistance = 5.0f; // Distancia máxima de movimiento hacia la izquierda y derecha
    public float speed = 2.0f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Calcula el nuevo valor de posición X
        float newX = startPosition.x + Mathf.PingPong(Time.time * speed, movementDistance * 2) - movementDistance;

        // Actualiza la posición solo en el eje X
        transform.position = new Vector3(newX, startPosition.y, startPosition.z);
    }
}
