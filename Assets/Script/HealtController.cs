using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealtController : MonoBehaviour
{
    [SerializeField] public float currentHealt;
    [SerializeField] public float maxHealt;
    [SerializeField] private Slider healtSlider;
    public event Action<int> OnDamageTaken;
    
    public event Action OnDeath;
    void Start()
    {
        
        currentHealt = maxHealt;
    
    }

    private void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealt -= damage;
        if (currentHealt <= 0)
        {
            currentHealt= 0;
            OnDeath?.Invoke();
        }
        else
        {
            OnDamageTaken?.Invoke(damage);
            healtSlider.value = currentHealt;
        }
    }
    [ContextMenu("TestDamage")]
    public void TestDamage()
    {
        TakeDamage(10);
    }
}
