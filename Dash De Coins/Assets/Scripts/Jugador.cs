using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Vector3 velocidadFinal = Vector3.zero;
    Vector3 cambioPosicion = Vector3.zero;
    int direccion = 1;

    const float gravity = 11.8f;
    private AudioSource audio;
    private void Start()
    {
       
    }
    void FixedUpdate()
    {
        cambioPosicion.x = direccion * (velocidadFinal.x * Time.deltaTime + Physics.gravity.x * (Mathf.Pow(Time.deltaTime, 2) / 2));
        cambioPosicion.y = direccion * (velocidadFinal.y * Time.deltaTime + Physics.gravity.y * (Mathf.Pow(Time.deltaTime, 2) / 2));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CentroJuego.cont = 0;
            gameObject.GetComponent<SpriteRenderer>().flipY = !gameObject.GetComponent<SpriteRenderer>().flipY;
            direccion *= -1;
            velocidadFinal = Vector3.zero;
        }
        gameObject.transform.Translate(cambioPosicion);

        velocidadFinal += Physics.gravity * Time.deltaTime;
          
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
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            velocidadFinal = Vector3.zero;  
        }
    }
}
