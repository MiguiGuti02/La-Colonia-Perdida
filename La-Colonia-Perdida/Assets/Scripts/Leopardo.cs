using UnityEngine;

public class Leopardo : MonoBehaviour
{
    public float velocidad = 3.0f; // Velocidad de movimiento del Leopardo
    private bool moviendoseHaciaDerecha = true; // Indicador de dirección

    private void Update()
    {
        // Mover el Leopardo
        if (moviendoseHaciaDerecha)
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        }

        // Cambiar dirección al llegar a un límite
        if (transform.position.x >= 14.5f) // Ajusta el límite derecho según tus necesidades
        {
            CambiarDireccion();
        }
        else if (transform.position.x <= 0.0f) // Ajusta el límite izquierdo según tus necesidades
        {
            CambiarDireccion();
        }
    }

    // Cuando colisiona con el jugador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("El Leopardo ha colisionado con el jugador.");
            CambiarDireccion(); // Cambia de dirección al colisionar con el jugador
        }
    }

    // Método para cambiar la dirección
    private void CambiarDireccion()
    {
        moviendoseHaciaDerecha = !moviendoseHaciaDerecha;
    }
}
