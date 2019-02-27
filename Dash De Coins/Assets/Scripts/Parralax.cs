using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parralax : MonoBehaviour
{
    //public GameObject background;
    public GameObject platform;

    //private GameObject nextBG;
    private GameObject nextPF;
    //private GameObject actualBG;
    private GameObject actualPF;
    public int velocidadPF ;
    //public int velocidadBG ;
    public float limit;
    public float deleteLimit;
    // Start is called before the first frame update
    void Start()
    {
        //actualBG = Instantiate(background);
        //nextBG = Instantiate(background, new Vector3(27.19f,0), Quaternion.identity);

        actualPF = Instantiate(platform);
        nextPF = Instantiate(platform, new Vector3(27.74f, -5.37f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        actualPF.transform.Translate(new Vector3(velocidadPF,0) * Time.deltaTime);
        if(actualPF.transform.position.x >= limit)
        {
            nextPF = Instantiate(platform, new Vector3(27.74f, -5.37f), Quaternion.identity);
            nextPF.transform.Translate(new Vector3(velocidadPF, 0) * Time.deltaTime);
            //nextBG = Instantiate(background,)
        }

        if(actualPF.transform.position.x <= deleteLimit)
        {
            Destroy(actualPF);
            actualPF = nextPF;
        }
    }
}
