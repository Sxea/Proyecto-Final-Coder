using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtController : MonoBehaviour
{
    public float hpMin;
    public int hpMax;
    public Image bar;
    void Start()
    {
        hpMin = hpMax;
    }

    
    void Update()
    {
        ControllerHealt();
        if(hpMin <= 0) 
        { 
            gameObject.SetActive(false);
        }
    }

    public void ControllerHealt()
    {
        bar.fillAmount = hpMin / hpMax;
    }
}
