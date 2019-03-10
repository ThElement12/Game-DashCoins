using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{

    private void OnMouseEnter()
    {
        gameObject.transform.localScale *= 1.2f;
    }

    private void OnMouseExit()
    {
        gameObject.transform.localScale /= 1.2f;
    }

    public void OnMouseUp()
    {
        switch (gameObject.name)
        {
            case "Quit":
                Application.Quit();
                break;
            case "Play":
                SceneManager.LoadScene("Dash de coins");
                break;
            case "MainMenu":
                CentroJuego.vida = 3;
                CentroJuego.monedas = 0;
                SceneManager.LoadScene("Menu");
                break;
            //case "Options":
               // GameObject.Find("New Text").GetComponent<MenuControl2>().ShowCanvas();
                //break;
        }
    }
}
