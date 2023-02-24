using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum Actions
{
    IDL = 0,
    HitLeft = 1,
    HitRight = 2,
    Block = 3,
    Jump = 4,
    WalkBack = 5,
    WalkForward = 6,
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public bool dontDestroyOnLoad;
    public static float healtMax = 1000f ;
    

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
