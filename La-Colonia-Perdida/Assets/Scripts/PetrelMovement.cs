using UnityEngine;

public class Petrel : MonoBehaviour
{
    [SerializeField] public float velocidad; // Velocidad de movimiento del Petrel
    [SerializeField] private bool moviendoseHaciaDerecha; // Indicador de dirección
    private Vector3 pos;
    private Rigidbody2D rb;
    public GameObject proyectilPrefab; // Asigna el prefab del proyectil en el Inspector
    public float tiempoDeVidaCaca = 3.0f; // Tiempo de vida de las cacas

    private void Start()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Mover el Leopardo
        rb.velocity = new Vector2(velocidad, rb.velocity.y);

        if (moviendoseHaciaDerecha && transform.position.x >= pos.x + 5f)
        {
            CambiarDireccion();
            LanzarProyectil();
        }
        else if (!moviendoseHaciaDerecha && transform.position.x <= pos.x - 5f)
        {
            CambiarDireccion();
            LanzarProyectil();
        }
    }

    // Método para cambiar la dirección
    public void CambiarDireccion()
    {
        moviendoseHaciaDerecha = !moviendoseHaciaDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;
    }

    // Método para lanzar el proyectil
    private void LanzarProyectil()
    {
        if (proyectilPrefab != null)
        {
            GameObject caca = Instantiate(proyectilPrefab, transform.position, Quaternion.identity);
            Destroy(caca, tiempoDeVidaCaca);
        }
        else
        {
            Debug.LogWarning("No se asignó un prefab de proyectil al Petrel.");
        }
    }

    // Método para manejar la colisión con el jugador
    
    
}