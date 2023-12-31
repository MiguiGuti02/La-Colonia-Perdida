using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MovimientoGuino : MonoBehaviour
{

    // Reinicio lvl 
    [SerializeField] private float limiteY = -40f; // Establece el l�mite en el que quieres reiniciar el juego

    private Rigidbody2D rb;

    private float dirH;
    private float deslizar;
<<<<<<< HEAD
    private float altura=0; //1 hacia arriba, -1 hacia abajo, 0 plano
=======
    private float altura = 0; //1 hacia arriba, -1 hacia abajo, 0 plano
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb

    [SerializeField] private float aceleracion = 12f;
    [SerializeField] private float deceleracion = 26f;
    private float velocidad;
    [SerializeField] private float vMax = 8f;
    private bool deslizando = false;

    [SerializeField] private float fuerzaSalto = 8f;

<<<<<<< HEAD
    private bool inmune=false;

    [SerializeField]private BoxCollider2D coll;
=======
    //private bool inmune = false;

    [SerializeField] private CapsuleCollider2D coll;
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject FinJuego;
<<<<<<< HEAD
=======
    [SerializeField] private GameObject CanvasPV;
    [SerializeField] private GameObject CanvasPausa;
    private Canvas canvas;
    public static bool pausa = false;

>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb

    public GameObject Krill;
    public GameObject Sardina;

<<<<<<< HEAD
    public static List<float> posicionKrill=new List<float>();
    public static List<float> posicionSardina = new List<float>();

    public static int nKrill = 0;
    public static int vida = 10;
=======
    public static List<float> posicionKrill = new List<float>();
    public static List<float> posicionSardina = new List<float>();

    public static int nKrill = 0;
    public static int vida = 5;
    private SpriteRenderer spriteRenderer;
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb

    [SerializeField] private float velocidadRebote;
    [SerializeField] private Vector2 reboteDaño;

    // Start is called before the first frame update
    void Start()
    {
        canvas = CanvasPV.GetComponent<Canvas>();
        ResizeCanvas();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        updateTextKrill();
        updateTextVida();
<<<<<<< HEAD
        altura=transform.position.y;
=======
        altura = transform.position.y;
        CanvasPV.SetActive(true);
        FinJuego.SetActive(false);
        CanvasPausa.SetActive(false);
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
    }

    // Update is called once per frame
    void Update()
    {
        if (!pausa)
        {
<<<<<<< HEAD
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
        }
        if(Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        altura=transform.position.y;
        // Comprueba si el jugador est� por debajo del l�mite Y
        if (altura < limiteY)
        {
            // Llama a una funci�n para reiniciar el juego (puedes implementar esta funci�n seg�n tus necesidades)
            ReiniciarJuego();
=======
            deslizar = Input.GetAxisRaw("Vertical");
            dirH = Input.GetAxisRaw("Horizontal");
            Aceleracion();
            Deslizamiento();
            if (Input.GetKeyDown(KeyCode.Space) && EnTierra())
            {
                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
            }
            if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
            altura = transform.position.y;
            // Comprueba si el jugador est� por debajo del l�mite Y
            if (altura < limiteY)
            {
                // Llama a una funci�n para reiniciar el juego (puedes implementar esta funci�n seg�n tus necesidades)
                ReiniciarJuego();
            }

            if (dirH < 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else if (dirH > 0)
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                pausa = true;
                CanvasPausa.SetActive(true);
                Time.timeScale = 0f;
            }
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
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
            Vector3 respawnPosition = latestCheckpoint.transform.position;
            respawnPosition.z = 0;
            transform.position = latestCheckpoint.transform.position;
<<<<<<< HEAD
            while (posicionKrill.Count > 0) 
=======
            while (posicionKrill.Count > 0)
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
            {
                float x1 = posicionKrill[0];
                float y1 = posicionKrill[1];
                Instantiate(Krill, new Vector3(x1, y1, 0), Quaternion.identity);
                posicionKrill.RemoveAt(0);
                posicionKrill.RemoveAt(0);
            }
            while (posicionSardina.Count > 0)
            {
                float x2 = posicionSardina[0];
                float y2 = posicionSardina[1];
                Instantiate(Sardina, new Vector3(x2, y2, 0), Quaternion.identity);
                posicionSardina.RemoveAt(0);
                posicionSardina.RemoveAt(0);

            }
            MovimientoGuino.nKrill = CheckpointController.guardarKrill;
            MovimientoGuino.vida = CheckpointController.guardarVida;
        }
        else
        {
            // Si no se encontr� ning�n checkpoint, puedes reiniciar el juego desde una posici�n predeterminada.
            // Aqu� puedes definir una posici�n de inicio predeterminada o simplemente reiniciar la escena.
<<<<<<< HEAD
            MovimientoGuino.vida = 10;
=======
            MovimientoGuino.vida = 5;
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
            MovimientoGuino.nKrill = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        updateTextKrill();
        updateTextVida();
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
        if (dirH == 0)
        {
            if (Mathf.Abs(velocidad) <= 0.1f)
            {
                velocidad = 0;
            }
            else
            {
                if (velocidad > 0)
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
            if (velocidad * dirH < 0)
            {
                velocidad += deceleracion * Time.deltaTime * dirH;
            }
            else
            {
                if (Mathf.Abs(velocidad) >= vMax)
                {
                    velocidad = vMax * dirH;
                }
                else
                {
                    velocidad += aceleracion * Time.deltaTime * dirH;
                }
            }
        }
    }

<<<<<<< HEAD
    void Deslizamiento(){
        if(deslizar==-1 && EnTierra()){
            if (altura<transform.position.y) deceleracion=12f;
            else if(altura>transform.position.y) deceleracion=0f;
            else deceleracion=4f;
        } 
        else deceleracion=12f;    
=======
 void Deslizamiento(){
        if (deslizar == -1 && EnTierra() && velocidad!=0)
        {
            if (altura < transform.position.y)
            {
                spriteRenderer.color = Color.white;
                deceleracion = 12f;
                deslizando = false;
            }
            else
            {
                spriteRenderer.color = Color.red;
                deslizando = true;
                if (altura > transform.position.y) deceleracion = 0f;
                else deceleracion = 4f;
            }

        }
        else
        {
            spriteRenderer.color = Color.white;
            deceleracion = 12f;
            deslizando = false;
        }
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
<<<<<<< HEAD
        
=======

        if (collision.gameObject.CompareTag("Orca"))
        {
            ReiniciarJuego();
        }

>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
        if (collision.gameObject.tag == "Krill")
        {   
            if (hayCheckPoint())
            {
                posicionKrill.Add(collision.gameObject.transform.position.x);
                posicionKrill.Add(collision.gameObject.transform.position.y);
            }
            int a = sumarKrill();
            if (a == 5)
            {
                if (MovimientoGuino.vida < 10)
                {
                    MovimientoGuino.vida=MovimientoGuino.vida + 2;
                    if (MovimientoGuino.vida > 10)
                    {
                        MovimientoGuino.vida = 10;
                    }
                }
                MovimientoGuino.nKrill = 0;
            }
            updateTextKrill();
            updateTextVida();
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "sardina")
        {
            if (hayCheckPoint())
            {
<<<<<<< HEAD
=======
                posicionKrill.Add(collision.gameObject.transform.position.x);
                posicionKrill.Add(collision.gameObject.transform.position.y);
            }
            int a = sumarKrill();
            if (a == 5)
            {
                if (MovimientoGuino.vida < 5)
                {
                    MovimientoGuino.vida = MovimientoGuino.vida + 1;
                    if (MovimientoGuino.vida > 5)
                    {
                        MovimientoGuino.vida = 5;
                    }
                }
                MovimientoGuino.nKrill = 0;
            }
            updateTextKrill();
            updateTextVida();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Sardina")
        {
            if (hayCheckPoint())
            {
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
                posicionSardina.Add(collision.gameObject.transform.position.x);
                posicionSardina.Add(collision.gameObject.transform.position.y);
            }

<<<<<<< HEAD
            if (MovimientoGuino.vida < 10)
            {
                MovimientoGuino.vida = MovimientoGuino.vida + 5;
                if (MovimientoGuino.vida > 10)
                {
                    MovimientoGuino.vida = 10;
=======
            if (MovimientoGuino.vida < 5)
            {
                MovimientoGuino.vida = MovimientoGuino.vida + 2;
                if (MovimientoGuino.vida > 5)
                {
                    MovimientoGuino.vida = 5;
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
                }
            }
            updateTextVida();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "FinPartida")
        {
            nKrill = 0;
<<<<<<< HEAD
            vida = 10;
            updateTextKrill();
            updateTextVida();
=======
            vida = 5;
            updateTextKrill();
            updateTextVida();
            CanvasPV.SetActive(false);
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
            FinJuego.SetActive(true);
            Time.timeScale = 0f;

        }

    }

    private static int sumarKrill()
    {
        MovimientoGuino.nKrill++;
<<<<<<< HEAD
       // Debug.Log(MovimientoGuino.nKrill);
=======
        // Debug.Log(MovimientoGuino.nKrill);
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
        updateTextKrill();
        return MovimientoGuino.nKrill;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
<<<<<<< HEAD
        
        if (collision.gameObject.CompareTag("Leopardo") && inmune==false)
=======

        if (collision.gameObject.CompareTag("Leopardo"))
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
        {
            foreach (ContactPoint2D punto in collision.contacts)
            {
                if (punto.normal.y >= 0.9)
                {
                    rebote();
                    Destroy(collision.gameObject);

                }
                else
                {
<<<<<<< HEAD
                    reboteImpacto();
                    MovimientoGuino.vida = MovimientoGuino.vida - 1;
                    MovimientoGuino.updateTextVida();
                    inmune=true;
                    StartCoroutine(wait(3.0f));
                    if (vida <= 0)
                    {
                       ReiniciarJuego();
=======
                    if (deslizando)
                    {
                        Destroy(collision.gameObject);
                    }
                    else
                    {
                        reboteImpacto();
                        MovimientoGuino.vida = MovimientoGuino.vida - 1;
                        MovimientoGuino.updateTextVida();
                        Physics2D.IgnoreLayerCollision(6, 7);
                        StartCoroutine(wait(1.5f));
                        if (vida <= 0)
                        {
                            ReiniciarJuego();
                        }
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
                    }
                }
            }
        }

<<<<<<< HEAD
    }

    public static bool hayCheckPoint()
    {
        bool res = false;
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
            if(latestCheckpoint != null)
            {
                res = true;
            }
        }
        return res;
    }

    
    private static void updateTextKrill()
    {
        GameObject krill = GameObject.FindGameObjectWithTag("UI");
        // cuando tengamos ese objeto buscamos su componente tipo texto y le vamos a poner ...
        krill.GetComponent<Text>().text="Krill:"+ MovimientoGuino.nKrill;
       
    }

    public static void updateTextVida() {
        GameObject vida = GameObject.FindGameObjectWithTag("UIvida");
        // cuando tengamos ese objeto buscamos su componente tipo texto y le vamos a poner ...
        vida.GetComponent<Text>().text = "Vida:" + MovimientoGuino.vida;
    }
    
    public void rebote()
    {
        rb.velocity = new Vector2(rb.velocity.x, velocidadRebote);
    }
    public void reboteImpacto()
    {
        rb.velocity = new Vector2(reboteDaño.x, reboteDaño.y);
        
        
    }
    IEnumerator wait(float tiempo)
    { 
        yield return new WaitForSeconds(tiempo);
        inmune=false;
    }
}
=======
    }

    public static bool hayCheckPoint()
    {
        bool res = false;
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
            if (latestCheckpoint != null)
            {
                res = true;
            }
        }
        return res;
    }


    private static void updateTextKrill()
    {
        GameObject krill = GameObject.FindGameObjectWithTag("UI");
        // cuando tengamos ese objeto buscamos su componente tipo texto y le vamos a poner ...
        krill.GetComponent<Text>().text = "Krill:" + MovimientoGuino.nKrill;

    }

    public static void updateTextVida()
    {
        GameObject vida = GameObject.FindGameObjectWithTag("UIvida");
        // cuando tengamos ese objeto buscamos su componente tipo texto y le vamos a poner ...
        vida.GetComponent<Text>().text = "Vida:" + MovimientoGuino.vida;
    }

    public void rebote()
    {
        rb.velocity = new Vector2(rb.velocity.x, velocidadRebote);
    }
    public void reboteImpacto()
    {
        rb.velocity = new Vector2(reboteDaño.x, reboteDaño.y);


    }
    IEnumerator wait(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    void ResizeCanvas()
    {
        canvas.renderMode = RenderMode.ScreenSpaceCamera;
        canvas.worldCamera = Camera.main;

        RectTransform rt = canvas.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(Screen.width, Screen.height);
    }



    }
>>>>>>> f3d1ca2aa126c444166ac60cc6ffad4807930afb
