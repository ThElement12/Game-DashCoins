using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CentroJuego : MonoBehaviour
{

    public static int monedas = 0, vida = 3;
    public TextMesh monedaCant;
    public TextMesh Mytimer, myLives, power;

    public enum EstadoJuego
    {
        Fase1,
        Fase2,
        Fase3
    };
    public static EstadoJuego estado;
    public GameObject background;
    public GameObject bloque;
    public GameObject bloqueVertical;
    public static int puntaje = 0;


    float distance;
    float aceleracion = 20f;
    const float _DISTANCIA = 3000;
    float tiempo;

    bool rotar = false;
    bool spike = false;
    bool primerMapa = true;
    public static bool hayPower = false;

    float tiempoInicio;
    float tiempoTranscurrido;
    int platCount = 0;
    float countDown = 20.0f;
    public static int powerUpActual = 1;

    bool extraLife = false;
 

    // Start is called before the first frame update
    void Start()
    {    
        estado = EstadoJuego.Fase1;
        Instantiate(background);
        if (!hayPower)
        {
            hayPower = true;
        }
        CargarMapa();
        primerMapa = false;
        
        tiempo = Mathf.Sqrt(2 * _DISTANCIA * aceleracion) / aceleracion;

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

                if (powerUpActual > 1)
                {
                    countDown -= Time.deltaTime;

                    power.text = "POWERUP!!!! " + "X" + powerUpActual.ToString() + ": " + countDown.ToString("N2");
                    if(countDown <= 0)
                    {
                        powerUpActual = 1;
                        countDown = 20.0f;
                        power.text = " ";
                    }
                }

                if (monedas % 100 == 0)
                {
                    if (!extraLife)
                    {
                        vida++;
                        extraLife = true;
                    }
                    
                }
                else
                {
                    extraLife = false;
                }
                break;

            case EstadoJuego.Fase2:
                vida--;
                if (vida == 0)
                {
                    estado = EstadoJuego.Fase3;
                }
                else
                {
                    SceneManager.LoadScene("Dash de Coins");
                }
                break;

            case EstadoJuego.Fase3:
                SceneManager.LoadScene("Final");
                break;
        }

        
    }
    private void FixedUpdate()
    {
        if (aceleracion < 120)
            aceleracion++;
        //= ACELEPASTTIME;

        distance += aceleracion * Mathf.Pow(Time.fixedDeltaTime,2)/2;
        Mytimer.text ="Puntos: " + ((int)distance).ToString();
        tiempoTranscurrido = Time.time - tiempoInicio;
        myLives.text = "Vidas: " + vida.ToString();

        if(tiempoTranscurrido >= tiempo)
        {
            primerMapa = false;
            CargarMapa();
            if (!hayPower)
            {
                hayPower = true;
            }
            //tiempo += Time.time;
        }

    }
    void CargarMapa()
    {

        TextAsset []contenido= {Resources.Load<TextAsset>("Mapa 1"), Resources.Load<TextAsset>("Mapa 2"), Resources.Load<TextAsset>("Mapa 3") };
        Quaternion rotacion;
        int mapa = 0;
        float i = 0, j = 0;
        GameObject nuevaCelda = null;
        tiempoInicio = Time.time;

        if (!primerMapa)
        {
            mapa = Random.Range(0,3);
            j = 15.6f;
        }


        foreach (string lineaActual in contenido[mapa].text.Split('\n'))
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
                    case '-':
                        nuevaCelda = bloque;
                        rotacion = bloque.transform.rotation;
                        spike = true;
                        rotar = true;
                        break;
                    case '*':
                        nuevaCelda = bloque;
                        rotacion = bloque.transform.rotation;
                        spike = true;
                        break;
                    default:
                        j += 3;
                        
                        continue;
                }

                
                nuevaCelda = Instantiate(nuevaCelda, new Vector3(j, -i), rotacion);
                if (rotar)
                {
                    nuevaCelda.GetComponent<SpriteRenderer>().flipY = true;
                    rotar = false;
                }
                if (spike)
                {
                    nuevaCelda.GetComponent<MovimientoPlataforma>().Spikes = true;
                    spike = false;
                }
                j += 3;
                

                
               
            }
            j = 0;
            if (!primerMapa)
            {
                j = 15.1f;
            }
            i += 3;
            

        }
    }

}
