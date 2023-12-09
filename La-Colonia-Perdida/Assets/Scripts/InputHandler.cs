using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{


    private Camera _mainCamera;

    [SerializeField] GameObject Anticaidas;
    [SerializeField] GameObject BotonAntiC;

    Renderer botonRenderer;


    private bool aComp = false;
    // Start is called before the first frame update
    void Start()
    {
        botonRenderer = BotonAntiC.GetComponent<Renderer>();
        botonRenderer.material.SetColor("_Color", Color.red);
        Anticaidas.SetActive(false);
        aComp = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(!context.started)
        {
            return;
        }

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if(!rayHit.collider)
        {
            return;
        }

        if(rayHit.collider.gameObject.tag == "Anticaidas" )
        {
            if (!aComp)
            {
                Anticaidas.SetActive(true);
                aComp = true;
                botonRenderer.material.SetColor("_Color", Color.green);
            }
            else
            {
                Anticaidas.SetActive(false);
                aComp=false;
                botonRenderer.material.SetColor("_Color", Color.red);
            }
        }
    }
}
