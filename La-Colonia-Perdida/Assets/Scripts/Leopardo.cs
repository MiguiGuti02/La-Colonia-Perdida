using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
<<<<<<< HEAD
using static UnityEditor.PlayerSettings;

public class Leopardo : MonoBehaviour
{
    [SerializeField] public  float velocidad; // Velocidad de movimiento del Leopardo
    [SerializeField] private  bool moviendoseHaciaDerecha; // Indicador de direcciÃ³n
    [SerializeField] private  Transform controladorSuelo;
=======

public class Leopardo : MonoBehaviour
{
    [SerializeField] public float velocidad; // Velocidad de movimiento del Leopardo
    [SerializeField] private bool moviendoseHaciaDerecha; // Indicador de dirección
    [SerializeField] private Transform controladorSuelo;
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
    [SerializeField] private float distancia;
    private Vector3 pos;
    private Rigidbody2D rb;

    private void Start()
    {
        pos = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {

        RaycastHit2D informacionSuelo = Physics2D.Raycast(controladorSuelo.position, Vector2.down, distancia);
        // Mover el Leopardo
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
        if (informacionSuelo == false)
        {
            CambiarDireccion();
        }

<<<<<<< HEAD
        // Cambiar direcciÃ³n al llegar a un lÃ­mite
        else { 
        if (moviendoseHaciaDerecha && transform.position.x >= pos.x + 5f) // Ajusta el lÃ­mite derecho segÃºn tus necesidades
        {

           CambiarDireccion();
        }
        else if (!moviendoseHaciaDerecha && transform.position.x <= pos.x - 5.3f) // Ajusta el lÃ­mite izquierdo segÃºn tus necesidades
        {
            CambiarDireccion();
        }

    }

 
=======
        // Cambiar dirección al llegar a un límite
        else
        {
            if (moviendoseHaciaDerecha && transform.position.x >= pos.x + 5f) // Ajusta el límite derecho según tus necesidades
            {

                CambiarDireccion();
            }
            else if (!moviendoseHaciaDerecha && transform.position.x <= pos.x - 5.3f) // Ajusta el límite izquierdo según tus necesidades
            {
                CambiarDireccion();
            }

        }


>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CambiarDireccion();

    }
<<<<<<< HEAD
            // MÃ©todo para cambiar la direcciÃ³n
   public void CambiarDireccion() {

            moviendoseHaciaDerecha = !moviendoseHaciaDerecha;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            velocidad *= -1;

          }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
    }

=======
    // Método para cambiar la dirección
    public void CambiarDireccion()
    {

        moviendoseHaciaDerecha = !moviendoseHaciaDerecha;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        velocidad *= -1;

    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controladorSuelo.transform.position, controladorSuelo.transform.position + Vector3.down * distancia);
    }

>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
}