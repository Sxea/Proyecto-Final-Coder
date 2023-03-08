using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Actors
{
    [SerializeField] private Transform Viking;
    [SerializeField] private float persuitDistance;
    [SerializeField] private Transform warriorPosition;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask layerToViking;
    [SerializeField] private float speed;
    

    public event Action<float> OnDamageEnemy;

    private void Start()
    {
        PJ.OnDamage += RecivedDamage;
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
}
