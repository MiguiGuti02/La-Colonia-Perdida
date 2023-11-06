using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetrelMovement : MonoBehaviour
{
    public Vector3 startPosition;
    public Vector3 endPosition;
    public float speed = 2.0f;

    private Vector3 currentTarget;

    void Start()
    {
        currentTarget = endPosition;
    }

    void Update()
    {
        // Mueve el objeto hacia el objetivo actual
        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);

        // Si el objeto alcanza el objetivo, cambia el objetivo
        if (transform.position == currentTarget)
        {
            if (currentTarget == startPosition)
            {
                currentTarget = endPosition;
            }
            else
            {
                currentTarget = startPosition;
            }
        }
    }
}
