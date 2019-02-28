using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    public int velocidadPF ;
    //public int velocidadBG ;
    //public float limit;
    public float deleteLimit;
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
        gameObject.transform.Translate(new Vector3(velocidadPF, 0) * Time.deltaTime);
        if (gameObject.transform.position.x <= deleteLimit)
        {
            Destroy(gameObject);

        }
    }
}
