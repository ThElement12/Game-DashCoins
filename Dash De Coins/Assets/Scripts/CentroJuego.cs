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
    public GameObject[] bloques = new GameObject[2];
    GameObject plataforma;
    int count = 20;
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
                    plataforma = Instantiate(bloques[0], new Vector3(14.24619f, -3.805211f), Quaternion.identity);
                    //plataforma.transform.Translate();
                    plataforma.GetComponent<Rigidbody>().AddForce(new Vector3(-10, 0), ForceMode.Impulse);
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
