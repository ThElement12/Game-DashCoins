using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentroJuego : MonoBehaviour
{

    public static int monedas = 0;
    public TextMesh monedaCant;
    float distance;
    public TextMesh Mytimer;
   
    public enum EstadoJuego
    {
        Fase1,
        Fase2
    };
    public static EstadoJuego estado;
    public GameObject background;
    public GameObject bloque;
    public GameObject bloqueVertical;

    bool rotar = false;

    int platCount = 0;
    public static int puntaje = 0;


    // Start is called before the first frame update
    void Start()
    {
        estado = EstadoJuego.Fase1;
        Instantiate(background);
        CargarMapa();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (estado)
        {
            case EstadoJuego.Fase1:
              
                if (platCount == 0)
                {
                    platCount = 300;
                    Instantiate(background, new Vector3(33.86f, -16.62f, 5f), Quaternion.identity);
                }
                else if (platCount > 0)
                {
                    platCount--;
                }
                monedaCant.text = "Monedas: " + monedas.ToString();
                //timer = Time.deltaTime;
                //distance += 0 + (aceleracion * Mathf.Pow(timer,2))/2;
                //Mytimer.text = distance.ToString();
                break;

            case EstadoJuego.Fase2:
                break;
        }

        
    }
    private void FixedUpdate()
    {

        distance += -MovimientoPlataforma.velocidad;
        Mytimer.text = "Puntos: " + ((int)distance).ToString();
    }
    void CargarMapa()
    {

        var contenido = Resources.Load<TextAsset>("Mapa 2"); //+ Random.Range(2,3).ToString());
        
        
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
                    case '/':
                        nuevaCelda = bloque;
                        rotacion = bloque.transform.rotation;
                        rotar = true;
                  
                        break;

                    default:
                        j += 4.25f;
                        continue;
                }

                
                nuevaCelda = Instantiate(nuevaCelda, new Vector3(j, -i), rotacion);
                if (rotar)
                {
                    nuevaCelda.GetComponent<SpriteRenderer>().flipY = true;
                }
                j += 4.25f;
                rotar = false;
            }
            j = 0;
            i+= 3;

        }
    }

}
