using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentroJuego : MonoBehaviour
{

    public enum EstadoJuego
    {
        Fase1,
        Fase2
    };
    public static EstadoJuego estado;
    public GameObject bloque;
    GameObject plataforma;
    float posicionY = -3.805211f;
    int count = 20, cantidadBloques = 10;

    // Start is called before the first frame update
    void Start()
    {
        estado = EstadoJuego.Fase1;
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case EstadoJuego.Fase1:
                if (count == 0)
                {
                    count = 20;
                    plataforma = Instantiate(bloque, new Vector3(14.24619f, posicionY), Quaternion.identity);
                    //plataforma.transform.Translate();
                    plataforma.GetComponent<Rigidbody>().AddForce(new Vector3(-10, 0), ForceMode.Impulse);
                    cantidadBloques--;
                    if (cantidadBloques == 0)
                    {
                        cantidadBloques = Random.Range(5, 8);
                        posicionY = Random.Range(-4, 2);
                    }
                }
                else
                {
                    count--;
                }

                break;

            case EstadoJuego.Fase2:
                break;
        }

        
    }
}
