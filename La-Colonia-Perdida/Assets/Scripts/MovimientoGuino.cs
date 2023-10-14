using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoGuino : MonoBehaviour
{

    private Rigidbody2D rb;

    private float dirH;


    private float velocidad = 7f;

    private float fuerzaSalto = 7f;

    private bool miraD = true;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        dirH = Input.GetAxisRaw("Horizontal");
        DarVuelta();
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
        rb.velocity = new Vector2(velocidad * dirH, rb.velocity.y);
    }

    private void DarVuelta()
    {
        if(miraD && dirH <0f || !miraD && dirH > 0f)
        {
            miraD = !miraD;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private bool EnTierra()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

}
