using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public enum Actions
{
    IDL = 0,
    HitLeft = 1,
    HitRight = 2,
    Block = 3,
    Jump = 4,
    WalkBack = 5,
    WalkForward = 6,
}
public class Viking : MonoBehaviour
{
    private Actions actions;
    [SerializeField] private float speed;
    [SerializeField] private Animator animationViking;
    private bool isActived;
    void Start()
    {
        
    }

    
    void Update()
    {
        Movement();
        AnimationViking();
    }
    private void Movement()
    {
        var hor = Input.GetAxisRaw("Horizontal");
        var direction = new Vector3(hor, 0, 0);
        transform.position += direction*speed*Time.deltaTime;
    }
    private void ActivedTranstion(bool actived)
    {
        animationViking.SetBool("WalkBack", actived);
       
    }

    
    
    
    private void AnimationViking()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ActivedTranstion(true);

        }
          
        if (Input.GetKeyDown(KeyCode.K))
        {
            ActivedTranstion(false);
        }    
        
        
        
    }
}
