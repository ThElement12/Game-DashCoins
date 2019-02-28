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
        //actualBG = Instantiate(background);
        //nextBG = Instantiate(background, new Vector3(27.19f,0), Quaternion.identity);

        //actualPF = Instantiate(platform);
        //nextPF = Instantiate(platform, new Vector3(27.74f, -5.37f), Quaternion.identity);
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
