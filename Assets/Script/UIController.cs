using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class UIController : MonoBehaviour
{
    
    
    [SerializeField] private GameObject activedCanvas;
    public bool isDeath;

    private void Start()
    {
        
        
    }
    private void Update()
    {
        GameOverUI();
    }
    private void GameOverUI()
    {
        if (isDeath)
        {
            
            activedCanvas.SetActive(true);
            
        }
        
            
    }
    
}
