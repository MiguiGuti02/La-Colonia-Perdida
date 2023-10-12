using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pingüino : MonoBehaviour
{
    float velocidad = 5f;
    Rigidbody rigidbody;
    float inputHorizontal;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody=GetComponent<Rigidbody>();
        rigidbody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        Vector2 velocidad2 = new Vector2(inputHorizontal*velocidad,rigidbody.velocity.y);
        rigidbody.velocity=velocidad2;
    }
}
