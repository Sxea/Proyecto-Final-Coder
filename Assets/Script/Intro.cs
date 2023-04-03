using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{
    private float timer;
    [SerializeField] private float maxTimer;
    [SerializeField] private GameObject barHealt;
    [SerializeField] private GameObject intro;
    void Start()
    {
        timer += Time.deltaTime;
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= maxTimer )
        {
           barHealt.SetActive( true );
           intro.SetActive( false );
        }
    }
}
