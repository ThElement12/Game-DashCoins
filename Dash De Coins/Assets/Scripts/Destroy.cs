﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    
    private void OnCollisionEnter(Collision collision)
    {
         
        if(collision.gameObject.tag == "Player")
        {
            CentroJuego.estado = CentroJuego.EstadoJuego.Fase2;
        }
  
       Destroy(collision.gameObject);
    }

}
