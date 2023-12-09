using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuInicio : MonoBehaviour
{
    MovimientoGuino player;
    // Start is called before the first frame update
    public void jugar()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void exit()
    {
        Application.Quit();
    }

}
