using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoGuino : MonoBehaviour
{

    // Reinicio lvl 
    [SerializeField] private float limiteY = -40f; // Establece el límite en el que quieres reiniciar el juego

    private Rigidbody2D rb;

    private float dirH;

    [SerializeField] private float aceleracion = 8f;
    [SerializeField] private float deceleracion = 12f;
    private float velocidad;
    [SerializeField] private float vMax = 8f;

    [SerializeField] private float fuerzaSalto = 8f;

    private bool miraD = true;

    [SerializeField]private BoxCollider2D coll;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        miraD = true;
    }

    // Update is called once per frame
    void Update()
    {
        dirH = Input.GetAxisRaw("Horizontal");
        Aceleracion();
        //DarVuelta();
        if (Input.GetKeyDown(KeyCode.Space) && EnTierra())
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }
        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // Comprueba si el jugador está por debajo del límite Y
        if (transform.position.y < limiteY)
        {
            // Llama a una función para reiniciar el juego (puedes implementar esta función según tus necesidades)
            ReiniciarJuego();
        }
    }

    void ReiniciarJuego()
    {
        // Encuentra todos los objetos de checkpoint en la escena
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();

        // Encuentra el checkpoint más reciente alcanzado
        Checkpoint latestCheckpoint = null;
        foreach (Checkpoint checkpoint in checkpoints)
        {
            if (checkpoint.isCheckpointReached)
            {
                latestCheckpoint = checkpoint;
            }
        }

        // Si se encontró un checkpoint válido, reposiciona al jugador en ese checkpoint
        if (latestCheckpoint != null)
        {
            Vector3 respawnPosition = latestCheckpoint.transform.position;
            respawnPosition.z = 0;
            transform.position = latestCheckpoint.transform.position;
        }
        else
        {
            // Si no se encontró ningún checkpoint, puedes reiniciar el juego desde una posición predeterminada.
            // Aquí puedes definir una posición de inicio predeterminada o simplemente reiniciar la escena.
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
    }

/*    private void DarVuelta()
    {
        if(miraD && dirH <0f || !miraD && dirH > 0f)
        {
            miraD = !miraD;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
*/
    private bool EnTierra()
    {
        //return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        //Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + 0.01f);
        //return Physics2D.OverlapCircle(groundCheck.position, groundCheckSize, groundLayer);

        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    private void Aceleracion()
    {
        if(dirH==0)
        {
            if(Mathf.Abs(velocidad)<=0.1f)
            {
                velocidad=0;
            }
            else
            {
                if(velocidad>0)
                {
                    velocidad -= deceleracion * Time.deltaTime;
                }
                else
                {
                    velocidad += deceleracion * Time.deltaTime;
                }
            }
        }
        else
        {
            if (velocidad*dirH<0)
            {
                velocidad += deceleracion * Time.deltaTime * dirH;
            }
            else
            {
                if(Mathf.Abs(velocidad) >= vMax)
                {
                    velocidad = vMax*dirH;
                }
                else
                {
                    velocidad += aceleracion * Time.deltaTime * dirH;
                }
            }
        }
    }

   
}
