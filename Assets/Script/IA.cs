using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    [SerializeField] private Transform Viking;
    [SerializeField] private float speed;
    [SerializeField] private float persuitDistance;
    void Start()
    {
        
    }

    
    void Update()
    {
        persuit();
    }

    private void persuit ()
    {
        var vectorToViking = Viking.position - transform.position;
        var distance = vectorToViking.magnitude;
        if (distance > persuitDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, Viking.gameObject.transform.position, speed * Time.deltaTime);
        }
        
    }
}
