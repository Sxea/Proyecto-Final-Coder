using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool dontDestroyOnLoad;
    
    

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }
   






}
