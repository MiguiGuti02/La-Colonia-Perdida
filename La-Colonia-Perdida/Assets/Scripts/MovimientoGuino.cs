using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovimientoGuino : MonoBehaviour
{

    // Reinicio lvl 
    [SerializeField] private float limiteY = -40f; // Establece el l�mite en el que quieres reiniciar el juego

    private Rigidbody2D rb;

    private float dirH;

    [SerializeField] private float aceleracion = 8f;
    [SerializeField] private float deceleracion = 12f;
    private float velocidad;
    [SerializeField] private float vMax = 8f;

    [SerializeField] private float fuerzaSalto = 8f;

    public static int nKrill=0;


    [SerializeField]private BoxCollider2D coll;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject FinJuego;
    public GameObject Krill;
    public static List<float> posicionKrill=new List<float>();
    // Start is called before the first frame update
    void Start()    
    {
        rb = GetComponent<Rigidbody2D>();
        updateText();
    }

    // Update is called once per frame
    void Update()
    {
        dirH = Input.GetAxisRaw("Horizontal");
        Aceleracion();
        if (Input.GetKeyDown(KeyCode.Space) && EnTierra())
        {
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }
        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

        // Comprueba si el jugador est� por debajo del l�mite Y
        if (transform.position.y < limiteY)
        {
            // Llama a una funci�n para reiniciar el juego (puedes implementar esta funci�n seg�n tus necesidades)
            ReiniciarJuego();
        }
    }

    void ReiniciarJuego()
    {
        // Encuentra todos los objetos de checkpoint en la escena
        CheckpointController[] checkpoints = FindObjectsOfType<CheckpointController>();

        // Encuentra el checkpoint m�s reciente alcanzado
        CheckpointController latestCheckpoint = null;
        foreach (CheckpointController checkpoint in checkpoints)
        {
            if (checkpoint.isCheckpointReached)
            {
                latestCheckpoint = checkpoint;
            }
        }
        
        // Si se encontr� un checkpoint v�lido, reposiciona al jugador en ese checkpoint
        if (latestCheckpoint != null)
        {
            foreach (var pos in posicionKrill)
            {
                Debug.Log(pos.ToString());
            }
            Vector3 respawnPosition = latestCheckpoint.transform.position;
            respawnPosition.z = 0;
            transform.position = latestCheckpoint.transform.position;

            do
            {
                float x = posicionKrill[0];
                float y= posicionKrill[1];
                Instantiate(Krill, new Vector3(x,y,0),Quaternion.identity);
                posicionKrill.RemoveAt(0);
                posicionKrill.RemoveAt(0);
            } while(posicionKrill.Count > 0);

            if (posicionKrill.Count == 0)
            {
                Debug.Log("lista vacia");
            }

        }
        else
        {
            // Si no se encontr� ning�n checkpoint, puedes reiniciar el juego desde una posici�n predeterminada.
            // Aqu� puedes definir una posici�n de inicio predeterminada o simplemente reiniciar la escena.
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        nKrill = 0;
        updateText();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(velocidad, rb.velocity.y);
    }

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Krill")
        {
            // Encuentra todos los objetos de checkpoint en la escena
            CheckpointController[] checkpoints = FindObjectsOfType<CheckpointController>();

            // Encuentra el checkpoint m�s reciente alcanzado
            CheckpointController latestCheckpoint = null;
            foreach (CheckpointController checkpoint in checkpoints)
            {
                if (checkpoint.isCheckpointReached)
                {
                    latestCheckpoint = checkpoint;
                }
            }
            if (latestCheckpoint != null) {
                posicionKrill.Add(collision.gameObject.transform.position.x);
                posicionKrill.Add(collision.gameObject.transform.position.y);
            }
            sumarKrill();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "FinPartida")
        {

            FinJuego.SetActive(true);
            Time.timeScale = 0f;
            
        }

    }

    private static void sumarKrill()
    {
        MovimientoGuino.nKrill++;
       // Debug.Log(MovimientoGuino.nKrill);
        updateText();
    }
    private static void updateText()
    {
        GameObject puntos = GameObject.FindGameObjectWithTag("UI");
        // cuando tengamos ese objeto buscamos su componente tipo texto y le vamos a poner ...
        puntos.GetComponent<Text>().text="Krill:"+nKrill;
    }
   
}
