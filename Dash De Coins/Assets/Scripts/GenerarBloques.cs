
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarBloques : MonoBehaviour
{
    public GameObject[] bloques = new GameObject[2];
    GameObject plataforma;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Gen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Gen()
    {
        while (true)
        {
            if(CentroJuego.estado == CentroJuego.EstadoJuego.Fase1)
            {
                plataforma = Instantiate(bloques[0], new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.identity);
                plataforma.GetComponent<Rigidbody2D>().AddForce(new Vector2(-10, 0), ForceMode2D.Impulse);
            }



           // yield return new WaitForSeconds(5);

        }
    }
    
}
