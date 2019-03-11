using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    Vector3 velocidadFinal = Vector3.zero;
    Vector3 cambioPosicion = Vector3.zero;
    int direccion = 1;
    public static bool isOnPlat = false;

    const float gravity = 11.8f;
    private AudioSource audio;

    private void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space)|| Input.GetMouseButton(0)) && isOnPlat)
        {
            gameObject.GetComponent<SpriteRenderer>().flipY = !gameObject.GetComponent<SpriteRenderer>().flipY;
            direccion *= -1;
            isOnPlat = false;
        }
    }
    void FixedUpdate()
    {
        cambioPosicion.x = velocidadFinal.x * Time.deltaTime + Physics.gravity.x * (Mathf.Pow(Time.deltaTime, 2) / 2);
        cambioPosicion.y = velocidadFinal.y * Time.deltaTime + Physics.gravity.y * (Mathf.Pow(Time.deltaTime, 2) / 2);

        gameObject.transform.Translate(cambioPosicion);
        velocidadFinal += direccion * Physics.gravity * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Coin")
        {
            audio = other.GetComponent<AudioSource>();
            audio.Play();
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(other.gameObject,2);
            CentroJuego.monedas += CentroJuego.powerUpActual ;
         
        }
        if(other.gameObject.tag == "PowerUp")
        {
            audio = other.GetComponent<AudioSource>();
            audio.Play();
            other.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(other.gameObject, 2);
            switch (other.gameObject.name)
            {
                case "PowerX2(Clone)":
                    CentroJuego.powerUpActual = 2;
                    break;
                case "PowerX3(Clone)":
                    CentroJuego.powerUpActual = 3; 
                    break;
                case "PowerX4(Clone)":
                    CentroJuego.powerUpActual = 4;
                    break;
            }
        }

    } 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Plataforma")
        {
            velocidadFinal = Vector3.zero;
            cambioPosicion = Vector3.zero;
        }

    }
}
