using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerMoney : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            CentroJuego.monedas++;
        }
    }
}
