using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelFinished : MonoBehaviour
{

    [SerializeField] private GameObject CanvasPausa;

    // Start is called before the first frame update
    public void tryagain()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
    public void exit()
    {
        Application.Quit();
    }

    public void reanudar()
    {
        CanvasPausa.gameObject.SetActive(false);
        Time.timeScale = 1f;
        MovimientoGuino.pausa = false;
    }
}
