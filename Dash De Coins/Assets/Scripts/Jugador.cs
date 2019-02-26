using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    const float gravity = 9.8f;

    /*private void OnCollisionEnter(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            collision.gameObject.transform.Rotate(new Vector3(0, 180f, 180f));
            if (Physics.gravity.y > 0)
            {
                // Normal gravity so downward force of -9.8
                Physics.gravity = new Vector3(0, gravity * (-1), 0);
            }
            else
            {
                // Inverse gravity
                Physics.gravity = new Vector3(0, gravity, 0);
            }
        }
    }*/

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && CentroJuego.cont == 1)
        {
            CentroJuego.cont = 0;
            gameObject.transform.Rotate(new Vector3(0, 180f, 180f));
            if (Physics.gravity.y > 0)
            {
                // Normal gravity so downward force of -9.8
                Physics.gravity = new Vector3(0, gravity * (-1), 0);
            }
            else
            {
                // Inverse gravity
                Physics.gravity = new Vector3(0, gravity, 0);
            }
        }
    }

   /* private void OnCollisionExit(Collision collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            collision.gameObject.transform.Rotate(new Vector3(0, 180f, 180f));
            if (Physics.gravity.y > 0)
            {
                // Normal gravity so downward force of -9.8
                Physics.gravity = new Vector3(0, gravity * (-1), 0);
            }
            else
            {
                // Inverse gravity
                Physics.gravity = new Vector3(0, gravity, 0);
            }
        }
    }*/
}
