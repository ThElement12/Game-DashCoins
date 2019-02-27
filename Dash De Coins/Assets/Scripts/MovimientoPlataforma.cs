using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public GameObject coin;
    GameObject moneda;
    int probMoneda;
    float relatividad;


    public static float velocidad = -10;
    // Start is called before the first frame update
    void Start()
    {
        probMoneda = Random.Range(1, 5);
        if(probMoneda < 3)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        gameObject.transform.Translate(new Vector3(velocidad, 0) * Time.deltaTime);
        if(gameObject.transform.position.x <= -17.06028f)
        {
            Destroy(gameObject);
            
        }
    }
}
