using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.Types;

public class Enemy : Actors
{
    [SerializeField] private Transform viking;
    [SerializeField] private float persuitDistance;
    [SerializeField] private Transform warriorPosition;
    [SerializeField] private LayerMask layerToViking;
    [SerializeField] private float speed;
    [SerializeField] private Animator ani;

    private void Start()
    {
      
       
        
    }
    void Update()
    {
       
        Persuit();


    }


    private void Persuit()
    {
        var vectorToViking = viking.position - transform.position;
        var distance = vectorToViking.magnitude;
        if (distance > persuitDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, viking.gameObject.transform.position, speed * Time.deltaTime);
            ani.SetBool("run", true);
        }
        else 
        { 
           ani.SetBool("run", false);
           
        }

    }
  


}
