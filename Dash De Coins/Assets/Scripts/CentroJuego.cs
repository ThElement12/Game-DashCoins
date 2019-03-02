using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentroJuego : MonoBehaviour
{
    public static int cont = 1;
    public static int monedas = 0;
    public TextMesh monedaCant;
    float timer;
    float distance, distance2;
    public TextMesh Mytimer;
    //const int ACELEPASTTIME = 2;
    float aceleracion = 10f;
    public enum EstadoJuego
    {
        Fase1,
        Fase2
    };
    public static EstadoJuego estado;
    public GameObject []nube = new GameObject[2];
    public GameObject background;
    public GameObject bloque;
    public GameObject bloqueAlreves;
    public GameObject bloqueVertical;

    int platCount = 0;
    GameObject plataforma, plataforma2;
    bool primeraFila = true;
    float posicionY = -3.805211f, posicionY2 = -1.805211f;
    int count = 20, cantidadBloques = 10, cantidadBloques2 = 10;
    public static int puntaje = 0;


    // Start is called before the first frame update
    void Start()
    {
        estado = EstadoJuego.Fase1;
        Instantiate(background);
        timer = Time.deltaTime;
       /* for(int i = 1, j = 1; i < 50; i+= 5, j+=2)
        {
            Instantiate(bloque,new Vector3(-10.24619f + i,posicionY),Quaternion.identity);
            if(Random.Range(1,3) < 2)
            {
                Instantiate(nube[Random.Range(0,1)], new Vector3(-10.25f + i, posicionY + Random.Range(2, 3), 2.5f), Quaternion.identity);
            }
            
        }*/
        CargarMapa();

        
        //platCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case EstadoJuego.Fase1:
              /*  if (count == 0)
                {
                    count = 20;

                    plataforma = Instantiate(bloque, new Vector3(14.24619f, posicionY), Quaternion.identity);

                    if (!primeraFila)
                    {
                        plataforma2 = Instantiate(bloque, new Vector3(14.24619f, posicionY2), Quaternion.identity);

                    }

                    cantidadBloques--;
                    cantidadBloques2--;

                    if (cantidadBloques == 0)
                    {
                        cantidadBloques = Random.Range(5, 8);
                        cantidadBloques2 = Random.Range(5, 8);
                    
                        posicionY = Random.Range(-4, 2);
                        posicionY2 = Random.Range(2,4);
                        primeraFila = false;
                    }
                }
                else
                {
                    count--;
                }
                if (platCount == 0)
                {
                    platCount = 300;
                    Instantiate(background, new Vector3(26.7f, -7.37f, 5f), Quaternion.identity);
                }
                else if (platCount > 0)
                {
                    platCount--;
                }
                monedaCant.text = "Monedas: " + monedas.ToString();
                //timer = Time.deltaTime;
                //distance += 0 + (aceleracion * Mathf.Pow(timer,2))/2;
                //Mytimer.text = distance.ToString();*/
                break;

            case EstadoJuego.Fase2:
                break;
        }

        
    }
    private void FixedUpdate()
    {
        if (aceleracion < 120)
            aceleracion++;//= ACELEPASTTIME;

        timer = Time.fixedDeltaTime;
        distance += ((aceleracion * Mathf.Pow(timer, 2)) / 2);
        distance2 = (int)distance;
        Mytimer.text = "Puntos: " + distance2.ToString();
    }
    void CargarMapa()
    {
        var contenido = Resources.Load<TextAsset>("Mapa 1");
        Quaternion rotacion;
        float i = 0, j = 0;
        GameObject nuevaCelda = null;


        foreach (string lineaActual in contenido.text.Split('\n'))
        {
            foreach(char celdaActual in lineaActual)
            {
                switch (celdaActual)
                {
                    case '_':
                        nuevaCelda = bloque;
                        rotacion = bloque.transform.rotation;
                        break;
                    case '|':
                        nuevaCelda = bloqueVertical;
                        rotacion = bloqueVertical.transform.rotation;
                        break;
                    case '-':
                        nuevaCelda = bloqueAlreves;
                        rotacion = bloqueAlreves.transform.rotation;
                        break;

                    default:
                        j += 6;
                        continue;
                }
                
                nuevaCelda = Instantiate(nuevaCelda, new Vector3(j, -i), rotacion);
                j += 6;
            }
            j = 0;
            i+= 3;

        }
    }

}
