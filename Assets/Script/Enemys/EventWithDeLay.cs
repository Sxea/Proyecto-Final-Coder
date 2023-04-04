using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
//using static UnityEditor.PlayerSettings;

public class EventWithDeLay : MonoBehaviour
{
    private float timer;
    [SerializeField] private float maxTimer;
    bool isActivated;
    bool isInvoke;
    [SerializeField] UnityEvent myEvent;


    private void Update()
    {
        if (!isActivated)
        {
            timer += Time.deltaTime;


        }
        if (timer >= maxTimer && isInvoke == false)
        {
            isActivated= true;
            myEvent.Invoke();
            isInvoke= true;
        }
    }
  
}
