using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PJ : Actors
{
    [SerializeField] private UnityEvent onDied;
    [SerializeField] private float speed;
    [SerializeField] private Animator animationViking;
    [SerializeField] private Rigidbody vikingRigidbody;
    [SerializeField] private float forceAmount;
    [SerializeField] private Transform footPosition;
    [SerializeField] private float distanceOfFloor;
    [SerializeField] private LayerMask layerTofloor;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private float maxTimer;
    private float timer;
    //private bool isActived;
    //public bool isDeath;
    public float hpMin;
    public int hpMax;
    public Image bar;
    
    void Start()
    {
        hpMin = hpMax;
    }


    void Update()
    {
        if (hpMin <= 0)
        {
            animationViking.SetTrigger("Dead");
            timer += Time.deltaTime;
            Death();
        }
        else
        {
            Movement();
            AnimationController();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RayCastJump();
            }
        }

        ControllerHealt();
       
    }
    private void Movement()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var ver = Input.GetAxisRaw("Vertical"); 
        var direction = new Vector3(hor, 0, ver);
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = MathF.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.position += direction * speed * Time.deltaTime;
        }
        
    }
           
            
            
    private void AnimationController()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            animationViking.SetBool("Run", true);
        }
        else
        {
            animationViking.SetBool("Run", false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            animationViking.SetTrigger("HitRight");
            
        }
            
        if (Input.GetKeyDown(KeyCode.J))
        {
            animationViking.SetTrigger("HitLeft");
        }
     
        if (Input.GetKeyDown(KeyCode.Space))
        animationViking.SetBool("Jump", true);
        else
        animationViking.SetBool("Jump", false);
        
    }
    private void RayCastJump()
    {
        var collaiderFloor = Physics.Raycast(footPosition.position, footPosition.forward, out RaycastHit raycastInfo, distanceOfFloor, layerTofloor);
        if (collaiderFloor)
        {
            Debug.Log($"layerToFloor{raycastInfo.collider.name}");
            vikingRigidbody.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);

        }
    }
    private void ControllerHealt()
    {
        bar.fillAmount = hpMin / hpMax;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Weapon"))
        {
            hpMin -= 20;
        }
    }
        
    public void Death()
    {
      
        if (timer >= maxTimer)
        {
            gameObject.SetActive(false);
            gameOver.SetActive(true);
            onDied.Invoke();
        }
    }
        
}
        
   








