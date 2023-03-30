using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RangeBoss : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Boss boss;
    [SerializeField] private int melee;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("PJ"))
        {
            melee = Random.Range(0, 4);
            switch (melee)
            {
                case 0:
                    //hit 1//
                    animator.SetFloat("skills", 0);
                    boss.hitSelect = 0;
                    break;
                case 1:
                    //hit 2//
                    animator.SetFloat("skills", 0.2f);
                    boss.hitSelect = 1;
                    break;
                case 2:
                    //Jump//
                    animator.SetFloat("skills",0.4f);
                    boss.hitSelect = 2;
                    break;
                case 3:
                    //FireBall//
                    if (boss.fase == 2)
                    {
                        animator.SetFloat("skills", 1);
                    }
                    else
                    {
                        melee = 0;
                    }
                    break;
            }
            animator.SetBool("walk", false);
            animator.SetBool("run", false);
            animator.SetBool("attack", true);
            boss.attack = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }




}
