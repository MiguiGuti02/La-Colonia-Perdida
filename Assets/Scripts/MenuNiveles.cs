using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    public void Nivel1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Back()
    {
        Debug.Log("He vuelto a la pagina de inicio");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
