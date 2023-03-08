using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PJ : Actors
{
    
    [SerializeField] private float speed;
    [SerializeField] private Animator animationViking;
    private bool isActived;
    [SerializeField] private Rigidbody vikingRigidbody;
    [SerializeField] private float forceAmount;
    [SerializeField] private Transform footPosition;
    [SerializeField] private float distanceOfFloor;
    [SerializeField] private LayerMask layerTofloor;
    

    private bool walkBack = false;
    private bool walkFoward = false;

    public event Action<bool> OnDamage;
    


    void Start()
    {
        
    }


    void Update()
    {
        Movement();
        AnimationController();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RayCastJump();
        }
    }
    private void Movement()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var direction = new Vector3(hor, 0, 0);
        transform.position += direction * speed * Time.deltaTime;
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
            OnDamage?.Invoke(animationViking);
        }


        if (Input.GetKeyDown(KeyCode.J))
            animationViking.SetTrigger("HitRight");
        if (Input.GetKeyDown(KeyCode.Space))
            animationViking.SetTrigger("Jump");
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

 
    private void OnHandlerDamage(float damage)
    {

    }

    public class HealtController
    {
        private float currentHealt;
        private float maxHealt;
        public event Action<float> OnHealt;





        public void RecivedDamage(float p_currentDamage)
        {
            currentHealt -= p_currentDamage;
            OnHealt?.Invoke(currentHealt);
        }
        public void HealtDamage(float p_currentHealt)
        {
            currentHealt += p_currentHealt;
            OnHealt?.Invoke(currentHealt);
        }
    }
}
