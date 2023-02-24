using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject[] PreFab;
    [SerializeField] private Transform spawnPoint;
    
   void Start()
    {
        ChoosePrefab();
    }

    
    void Update()
    {
        
    }
    private void ChoosePrefab()
    {
        var choosenPF = Random.Range(0, PreFab.Length);
        Instantiate(PreFab[choosenPF], spawnPoint.position,Quaternion.identity);
        Debug.Log("anduvo");
    }
}
