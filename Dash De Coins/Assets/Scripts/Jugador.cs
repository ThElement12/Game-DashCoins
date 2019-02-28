using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    const float gravity = 11.8f;
    private AudioSource audio;
    private void Start()
    {
       
    }
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CentroJuego.cont == 1)
        {
            CentroJuego.cont = 0;
            gameObject.GetComponent<SpriteRenderer>().flipY = !gameObject.GetComponent<SpriteRenderer>().flipY;
            if (Physics.gravity.y > 0)
            {
                // Normal gravity
                Physics.gravity = new Vector3(0, -gravity, 0);
            }
            else
            {
                // Inverse gravity
                Physics.gravity = new Vector3(0, gravity, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            audio = other.GetComponent<AudioSource>();
            audio.Play();
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(other.gameObject,2);
            CentroJuego.monedas++;
            

        }
    }
}
