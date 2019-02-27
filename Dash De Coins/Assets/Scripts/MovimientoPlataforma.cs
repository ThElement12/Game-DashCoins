using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlataforma : MonoBehaviour
{
    public static float velocidad = -10;
    // Start is called before the first frame update
    void Start()
    {
        
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
