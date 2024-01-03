using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{


    private Camera _mainCamera;

    [SerializeField] GameObject Anticaidas;
    [SerializeField] GameObject BotonAntiC;
    [SerializeField] GameObject ON;
    [SerializeField] GameObject OFF;


    [SerializeField] SpriteRenderer botonSpriteRenderer;
    [SerializeField] Sprite SpriteOff;
    [SerializeField] Sprite SpriteOn;


    private bool aComp = false;
    // Start is called before the first frame update
    void Start()
    {
        botonSpriteRenderer.sprite = SpriteOff;
        Anticaidas.SetActive(false);
        ON.SetActive(false);
        OFF.SetActive(true);
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
                botonSpriteRenderer.sprite = SpriteOn;
                ON.SetActive(true);
                OFF.SetActive(false);
            }
            else
            {
                Anticaidas.SetActive(false);
                aComp=false;
                botonSpriteRenderer.sprite = SpriteOff;
                ON.SetActive(false);
                OFF.SetActive(true);
            }
        }
    }
}
