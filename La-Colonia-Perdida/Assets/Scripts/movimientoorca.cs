using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoorca : MonoBehaviour
{

    public float minY;
    public float maxY;
    public float TiempoEspera = 5f;
    public float Velocidad = 1f;

    private GameObject _lugarObjetivo;

    // Start is called before the first frame update
    void Start()
    {
        UpdateObjeto();
        StartCoroutine("Patrullar");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateObjeto()
    {
        if (_lugarObjetivo == null)
        {
            _lugarObjetivo = new GameObject("Sitio_objetivo");
        }

        // Cambia la posición del objetivo en el eje Y
        _lugarObjetivo.transform.position = new Vector2(transform.position.x, _lugarObjetivo.transform.position.y == minY ? maxY : minY);
    }

    private IEnumerator Patrullar()
    {
        while (true)
        {
            // Obtiene la dirección hacia el objetivo
            Vector2 direction = _lugarObjetivo.transform.position - transform.position;

            // Si estamos muy cerca del objetivo, actualiza el objetivo
            if (direction.magnitude < 0.1f)
            {
                UpdateObjeto();
            }

            // Se desplaza hacia el objetivo
            transform.Translate(direction.normalized * Velocidad * Time.deltaTime);

            yield return null;
        }
    }


}
