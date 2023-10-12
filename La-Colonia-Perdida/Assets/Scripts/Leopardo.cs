using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leopardo : MonoBehaviour
{   
    float velocidad = 2f;
    float rango = 4f;
    float posIni;
    Vector2 direccion;

    // Start is called before the first frame update
    void Start()
    {
        posIni=transform.position.x;
        direccion=Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion*velocidad*Time.deltaTime);
        if(Mathf.Abs(transform.position.x - posIni) >= rango){
            Girar();
        } 
    }

    void Girar()
    {
        direccion = -direccion;        
    }
}
