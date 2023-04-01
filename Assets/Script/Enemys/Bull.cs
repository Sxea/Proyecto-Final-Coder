using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bull : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform viking;
    [SerializeField] private float timeDestroyBullet;
    private MonsterEnemy wizard;
    void Start()
    {
      
    }

    
    void Update()
    {
        Destroy(gameObject, timeDestroyBullet);
        transform.position += viking.position * speed * Time.deltaTime;
    }
}
