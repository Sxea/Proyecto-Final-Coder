using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IA : MonoBehaviour
{
    [SerializeField] private Transform Viking;
    [SerializeField] private float speed;
    [SerializeField] private float persuitDistance;
    [SerializeField] private Transform warriorPosition;
    [SerializeField] private float raycastDistance;
    [SerializeField] private LayerMask layerToViking;
    [SerializeField] private Rigidbody warriorRigidbody;
    [SerializeField] private float forceAmount;
    [SerializeField] private Transform footPosition;
    [SerializeField] private float distanceOfFloor;
    [SerializeField] private LayerMask layerTofloor;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.V))
        {
            CreateRayCast();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RayCastJump();
        }

    }

   
    private void CreateRayCast()
    {
        var collaided = Physics.Raycast(warriorPosition.position, warriorPosition.forward,out RaycastHit raycastInfo, raycastDistance, layerToViking);
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

    private void RayCastJump()
    {
        var collaiderFloor = Physics.Raycast(footPosition.position, footPosition.forward, out RaycastHit raycastInfo, distanceOfFloor, layerTofloor);
        if (collaiderFloor)
        {
            Debug.Log($"layerToFloor{raycastInfo.collider.name}");
            warriorRigidbody.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);

        }
        else
            Debug.Log("hasn´t collaider whit nothing");
    }
}


