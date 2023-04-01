using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterEnemy : MonoBehaviour
{
    [SerializeField] private Transform pointShoot;
    [SerializeField] private Animator ani;
    [SerializeField] private GameObject fireBall;
    [SerializeField] private Transform viking;
    private void Shoot()
    {
        Instantiate(fireBall, pointShoot.position, Quaternion.identity);
    }    
    private void Update()
    {
        Shoot();
        Look();
        
    }
    private void Look()
    {
        gameObject.transform.LookAt(viking.localPosition);
    }


 }
