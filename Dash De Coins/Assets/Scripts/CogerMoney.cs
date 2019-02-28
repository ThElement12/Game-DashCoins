using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerMoney : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip moneda;
    private void Start()
    { 
       audio = GetComponent<AudioSource>();
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {

            audio.PlayOneShot(moneda,1);
            
            Destroy(gameObject);
            CentroJuego.monedas++;
        }
    }
}
