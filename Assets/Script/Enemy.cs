using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking.Types;

public class Enemy : Actors
{
    [SerializeField] private Transform Viking;
    [SerializeField] private float persuitDistance;
    [SerializeField] private Transform warriorPosition;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask layerToViking;
    [SerializeField] private float speed;
    [SerializeField] private UnityEvent life;
    
    // borrar
    ButtonPlay button;

    public event Action<float> OnDamageEnemy;

    private void Start()
    {
       button= GetComponent<ButtonPlay>(); //solamente si la script esta en el mismo gameobj
       button = GetComponentInChildren<ButtonPlay>();// solamente busca dentro de sus hijos 
       button = FindObjectOfType<ButtonPlay>(); //solamente si la script no esta en este gameobj
       
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            CreateRayCast();
        }
       
       
    }


    private void CreateRayCast()
    {
        var collaided = Physics.Raycast(warriorPosition.position, warriorPosition.forward, out RaycastHit raycastInfo, raycastDistance, layerToViking);
        if (collaided)
        {
            Debug.Log($"layerToViking{raycastInfo.collider.name}");

            var vectorToViking = Viking.position - transform.position;
            var distance = vectorToViking.magnitude;
            if (distance > persuitDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, Viking.gameObject.transform.position, speed * Time.deltaTime);
            }
        }
        else
            Debug.Log("hasn´t collaider whit nothing");
    }

    private void OnHandlerDamageEnemy(float damageEnemy)
    {
        OnDamageEnemy?.Invoke(damageEnemy);
    }
    private void RecivedDamage()
    {
        
        Debug.Log("recived OnDamage,from PJ , to Enemy");
    }
    public void MeMori(string texto)
    {
        Debug.Log(texto);
    }

    private void healtEnemy()
    {
        life.Invoke();
    }
}
