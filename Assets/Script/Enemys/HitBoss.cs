using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBoss : MonoBehaviour
{
    [SerializeField] private int damage;

    private void OnTriggerEnter(Collider coll)
    {
       if (coll.CompareTag("PJ"))
        {
            coll.GetComponent<HealtController>().hpMin -= damage;
        }
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
