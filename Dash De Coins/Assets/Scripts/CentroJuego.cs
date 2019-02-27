using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentroJuego : MonoBehaviour
{
    public static int cont = 1;
    public static int monedas = 0;
    public enum EstadoJuego
    {
        Fase1,
        Fase2
    };
    public static EstadoJuego estado;
    bool primeraFila = true;
    public GameObject bloque;
    GameObject plataforma, plataforma2;
    float posicionY = -3.805211f, posicionY2 = -1.805211f;
    int count = 20, cantidadBloques = 10, cantidadBloques2 = 10;
    public static int puntaje = 0;


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

                    if (!primeraFila)
                    {
                        plataforma2 = Instantiate(bloque, new Vector3(14.24619f, posicionY2), Quaternion.identity);

                    }

                    cantidadBloques--;
                    cantidadBloques2--;

                    if (cantidadBloques == 0)
                    {
                        cantidadBloques = Random.Range(5, 8);
                        cantidadBloques2 = Random.Range(5, 8);
                    
                        posicionY = Random.Range(-4, 2);
                        posicionY2 = Random.Range(2,4);
                        primeraFila = false;
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
