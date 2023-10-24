using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGuino : MonoBehaviour
{

    private Rigidbody2D rb;

    private float dirH;

    private float aceleracion = 8f;
    private float deceleracion = 12f;
    private float velocidad;
    private float vMax = 8f;

    private float fuerzaSalto = 8f;

    private bool miraD = true;

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
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
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
