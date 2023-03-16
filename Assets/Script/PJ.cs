using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
    private bool isActived;
    public bool isDeath;
    private bool walkBack = false;
    private bool walkFoward = false;

    
    
    


    void Start()
    {
        
    }


    void Update()
    {
        if (isDeath)
        {
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


        if (Input.GetKey(KeyCode.A))
        {
            animationViking.SetBool("WalkBack", true);
            walkBack = true;
        }
        else
        {
            animationViking.SetBool("WalkBack", false);
            walkBack = false;
        }
        if (Input.GetKey(KeyCode.D))
        {
            animationViking.SetBool("WalkFoward", true);

        }
        else
        {
            animationViking.SetBool("WalkFoward", false);
            walkFoward = false;
        }

        if (Input.GetKeyDown(KeyCode.H))
            animationViking.SetTrigger("Block");
        if (Input.GetKeyDown(KeyCode.K))
        {
            animationViking.SetTrigger("HitLeft");
            
        }


        if (Input.GetKeyDown(KeyCode.J))
            animationViking.SetTrigger("HitRight");
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animationViking.SetBool("Jump", true);
        }
        else
        {
            animationViking.SetBool("Jump", false);
        }
            
    }







    private void RayCastJump()
    {
        var collaiderFloor = Physics.Raycast(footPosition.position, footPosition.forward, out RaycastHit raycastInfo, distanceOfFloor, layerTofloor);
        if (collaiderFloor)
        {
            Debug.Log($"layerToFloor{raycastInfo.collider.name}");
            vikingRigidbody.AddForce(Vector3.up * forceAmount, ForceMode.Impulse);

        }
        else
            Debug.Log("hasn´t collaider whit nothing");
    }

 
    public void Death()
    {
        onDied.Invoke();
    }

    public void Evento()
    {
        Debug.Log("el evento se activo");

    }

}
