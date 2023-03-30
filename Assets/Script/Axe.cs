using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        coll.GetComponent<Boss>().hpMin -= 50;

    }

    void Update()
    {
        
    }
}
