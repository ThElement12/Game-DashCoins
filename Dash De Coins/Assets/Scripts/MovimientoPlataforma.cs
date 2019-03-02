using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public GameObject coin;
    GameObject moneda;
    int probMoneda;
    float relatividad, aceleracion = 0.000000000003f;


    public static float velocidad = -10;
    // Start is called before the first frame update
    void Start()
    {
       /* probMoneda = Random.Range(1, 5);
        if(probMoneda < 3)
        {

            if(GameObject.FindGameObjectWithTag("Player") != null)
            {
                relatividad = GameObject.FindGameObjectWithTag("Player").transform.position.y - gameObject.transform.position.y;

                if(relatividad < 0)
                {
                    moneda = Instantiate(coin, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - 1), Quaternion.identity);
                }
                else
                {
                    moneda = Instantiate(coin, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + 1), Quaternion.identity);
                }
                moneda.transform.parent = gameObject.transform;
            }
            
        }*/
    }

    private void FixedUpdate()
    {
        if(gameObject.tag == "Plataforma 90"){
            gameObject.transform.Translate(new Vector3(0,-velocidad) * Time.deltaTime);

            if (gameObject.transform.position.x <= -17.06028f)
            {
                Destroy(gameObject);

            }
            velocidad -= aceleracion;

        }
        else if(gameObject.tag == "Plataforma Inversa")
        {
            gameObject.transform.Translate(new Vector3(velocidad, 0) * Time.deltaTime);

            if (gameObject.transform.position.x <= -17.06028f)
            {
                Destroy(gameObject);

            }
            velocidad -= aceleracion;
        }
        else
        {
            gameObject.transform.Translate(new Vector3(velocidad, 0) * Time.deltaTime);

            if (gameObject.transform.position.x <= -17.06028f)
            {
                Destroy(gameObject);

            }
            velocidad -= aceleracion;

        }
        
        
    }
}
