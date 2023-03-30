using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull : MonoBehaviour
{
    [SerializeField] private float chronometer;
    void Start()
    {
        
    }

    
    void Update()
    {
        chronometer += 1 * Time.deltaTime;
        if (chronometer>3) 
        { 
            gameObject.SetActive( false );
            chronometer= 0;
        }
        transform.Translate(Vector3.forward * 15 * Time.deltaTime);
    }
}
