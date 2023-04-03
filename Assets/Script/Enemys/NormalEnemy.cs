using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Networking.Types;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class NormalEnemy : MonoBehaviour
{
    [SerializeField] int rutine;
    [SerializeField] float chronometer;
    [SerializeField] Animator ani;
    [SerializeField] Quaternion angel;
    [SerializeField] float grade;
    [SerializeField] GameObject target;
    [SerializeField] bool attack;
    public float hpMin;
    public float hpMax;
    public Image bar;
    private float timer;
    [SerializeField] private float maxTimer;
    
    void Start()
    {
        hpMin = hpMax;
        ani  = GetComponent<Animator>();
        target = GameObject.Find("Viking");
    }

    private void ControllerEnemy()
    {
        if (Vector3.Distance(transform.position, target.transform.position) > 5) 
        {
            ani.SetBool("run", false);
            chronometer += 1 * Time.deltaTime;
            if (chronometer >= 4)
            {
                rutine = Random.Range(0, 2);
                chronometer = 0;
            }
            switch (rutine)
            {
                case 0:
                    ani.SetBool("walk", false);
                    break;
                case 1:
                    grade = Random.Range(0, 360);
                    angel = Quaternion.Euler(0, grade, 0);
                    rutine++;
                    break;
                case 2:
                    transform.rotation = Quaternion.RotateTowards(transform.rotation, angel, 0.5f); ;
                    transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                    ani.SetBool("walk", true);
                    break;
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, target.transform.position) > 1 && !attack)
            {
                var lookPos = target.transform.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                ani.SetBool("walk", false);
                
                ani.SetBool("run", true);
                transform.Translate(Vector3.forward * 2 * Time.deltaTime);
                ani.SetBool("attack", true);
            }
            else
            {
                
                ani.SetBool("walk", false);
                ani.SetBool("run", false);
                
                ani.SetBool("attack", true);
                attack = true;
            }
           
        }
    }
    private void FinalAnimator()
    {
        ani.SetBool("attack", false);
        attack= false;
    }

    void Update()
    {
        if (hpMin <= 0)
        {
            ani.SetTrigger("Dead");
            timer += Time.deltaTime;
            Death();
        }
        else
        {
            ControllerEnemy();
            ControllerHealt();
        }
    }
    private void ControllerHealt()
    {
        bar.fillAmount = hpMin / hpMax;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Axe"))
        {
            hpMin -= 30;
            Debug.Log("recibi daño");
        }
    }
       
    
    public void Death()
    {
        if (timer >= maxTimer)
        {
            gameObject.SetActive(false);
        }
    }

}
        


