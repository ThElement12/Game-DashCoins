
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBloques : MonoBehaviour
{
    public GameObject[] bloques = new GameObject[2];
    GameObject plataforma;
    int count = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (CentroJuego.estado == CentroJuego.EstadoJuego.Fase1)
        {
            if (count == 0)
            {
                count = 20;
                plataforma = Instantiate(bloques[0], new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
                plataforma.GetComponent<Rigidbody>().AddForce(new Vector3(-10, 0), ForceMode.Impulse);
            }
            else
            {
                count--;
            }
        }
    }
    
}
