using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float chronometer1;
    void Start()
    {
        
    }

    
    void Update()
    {
        transform.Translate(Vector3.forward * 6 * Time.deltaTime);
        transform.localScale += new Vector3(3, 3, 3) * Time.deltaTime;
        chronometer1 += 1 * Time.deltaTime;
        if (chronometer1 > 1f)
        {
            transform.localScale = new Vector3(1,1,1);
            gameObject.SetActive(false);
            chronometer1 = 0;
        }
    }
}
