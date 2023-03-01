using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum PrefabType
{
    Viking,
    Warrior,
    Egyptian,
}
public class Spawn : MonoBehaviour
{
    [SerializeField] private List<GameObject> PreFab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private int amountInstantiate = 4;
    [SerializeField] private List<GameObject> viking , warrior , egyptian ;
    [SerializeField] private PrefabType warriorSpawn;



    private Dictionary<PrefabType, List<GameObject> > PrefabDictionary =
        new Dictionary<PrefabType, List<GameObject>>();

    private void PopulateDictionary()
    {
        PrefabDictionary.Add(PrefabType.Viking, viking);
        PrefabDictionary.Add(PrefabType.Warrior, warrior);
        PrefabDictionary.Add(PrefabType.Egyptian, egyptian);
    }

    private void Awake()
    {
        for (int i =0; i < amountInstantiate; i++)
        {
            ChoosePrefab();
        }
       // var preFabSpawn = PrefabDictionary[PrefabType.Warrior];
        
        /* NO FUNCIONA !
          if (PrefabDictionary.TryGetValue(warriorSpawn, out var preFabToSpawn) )
        {
             preFabToSpawn;
        }*/
    }
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    private void ChoosePrefab()
    {
        var choosenPF = Random.Range(0, PreFab.Count);
        Instantiate(PreFab[choosenPF], spawnPoint.position,Quaternion.identity);
        Debug.Log("anduvo");
    }
}
