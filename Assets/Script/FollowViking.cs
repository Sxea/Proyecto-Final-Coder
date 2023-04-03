using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowViking : MonoBehaviour
{
    [SerializeField] private GameObject viking;

    void Start()
    {
        
    }

    
    void Update()
    {
        transform.position=viking.transform.position + new Vector3 (3.37f, 1.42f, 20.15f);
    }
}
