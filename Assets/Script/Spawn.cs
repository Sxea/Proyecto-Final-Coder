using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] PreFab;

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void ChoosePrefab()
    {
        var choosenMinion = Random.Range(0, PreFab.Length);
        //return PreFab[choosenMinion];
    }
}
