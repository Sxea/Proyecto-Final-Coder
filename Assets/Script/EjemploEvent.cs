using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploEvent : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.GetComponent<PJ>().Evento();
        

        
    }
}
