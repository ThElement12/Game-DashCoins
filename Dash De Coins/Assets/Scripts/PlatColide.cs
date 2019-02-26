using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatColide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CentroJuego.cont = 1;
        }
    }
}
