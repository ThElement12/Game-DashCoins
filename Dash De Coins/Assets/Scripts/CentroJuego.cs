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
    
    // Start is called before the first frame update
    void Start()
    {
        estado = EstadoJuego.Fase1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
