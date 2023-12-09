using UnityEngine;

public class Camara : MonoBehaviour
{
    public Transform target; // Referencia al Transform del jugador
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        // Actualiza la posici�n de la c�mara de manera suave para seguir al jugador
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, transform.position.y, transform.position.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
