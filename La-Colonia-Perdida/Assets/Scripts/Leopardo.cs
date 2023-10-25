using UnityEngine;

public class Leopardo : MonoBehaviour
{
    public float velocidad = 3.0f; // Velocidad de movimiento del Leopardo
    private bool moviendoseHaciaDerecha = true; // Indicador de direcci�n

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

        // Cambiar direcci�n al llegar a un l�mite
        if (transform.position.x >= 14.5f) // Ajusta el l�mite derecho seg�n tus necesidades
        {
            CambiarDireccion();
        }
        else if (transform.position.x <= 0.0f) // Ajusta el l�mite izquierdo seg�n tus necesidades
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
            CambiarDireccion(); // Cambia de direcci�n al colisionar con el jugador
        }
    }

    // M�todo para cambiar la direcci�n
    private void CambiarDireccion()
    {
        moviendoseHaciaDerecha = !moviendoseHaciaDerecha;
    }
}
