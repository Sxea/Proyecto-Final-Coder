using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class CanvasController : MonoBehaviour
{
    [SerializeField] private PJ viking;
    [SerializeField] private Enemy enemy;
    void Start()
    {
        viking.OnHealt += HealtUpdateUI;
        enemy.OnDamageEnemy += HealtUpdateUI;


    }

    
    void Update()
    {
        
    }

    private void HealtUpdateUI()
    {
        Debug.Log("recived Onhealt,from PJ , to CanvasController");
        Debug.Log("recived OnDamage ,from Enemy , to CanvasController");
    }
}
