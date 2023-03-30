using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] private int routine;
    [SerializeField] private float chronometer;
    [SerializeField] private float timeRoutine;
    [SerializeField] private Animator animator;
    [SerializeField] private Quaternion angel;
    [SerializeField] private float degree;
    [SerializeField] private GameObject target;
    [SerializeField] public bool attack;
    [SerializeField] private RangeBoss range;
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] hit;
    [SerializeField] public int hitSelect;
    
    [SerializeField] public int fase = 1;
    [SerializeField] public float hpMin;
    [SerializeField] public float hpMax;
    [SerializeField] private Image bar;
    [SerializeField] private AudioSource music;
    [SerializeField] private bool dead;
    /// <summary>
    /// flamethrower
    /// </summary>
    [SerializeField] private bool flamethrower;
    [SerializeField] private List<GameObject> pool = new List<GameObject>();
    [SerializeField] private GameObject fire;
    [SerializeField] private GameObject head;
    [SerializeField] private float chronometer2;

    /// <summary>
    /// Jump Distance
    /// </summary>
    
    [SerializeField] private float jumpDistance;
    [SerializeField] private bool directionSkill;

    /// <summary>
    /// fire Ball ///
    /// </summary>
    [SerializeField] private GameObject fireBall;
    [SerializeField] private GameObject point;
    [SerializeField] private List<GameObject> pool2 = new List<GameObject>();
    

    void Start()
    {
       animator = GetComponent<Animator>();
       target = GameObject.Find("Viking"); // chequear si esto anda 
    }

   private void ControllerBoss()
    {
        if (Vector3.Distance(transform.position, target.transform.position)<15)
        {
            var lookPos = target.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            point.transform.LookAt(target.transform.position);
            music.enabled= true;

            if (Vector3.Distance(transform.position, target.transform.position)> 1 && !attack)
            {
                switch (routine)
                {
                    case 0:
                        // Walk //
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.SetBool("walk", true);
                        animator.SetBool("run" , false);
                        if (transform.rotation == rotation) 
                        { 
                            transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        }
                        animator.SetBool("attack", false);
                        chronometer += 1 * Time.deltaTime;
                        if (chronometer>timeRoutine) 
                        { 
                            routine = Random.Range(0, 5);
                            chronometer= 0;
                        }
                        break;
                    case 1:
                        //run//
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animator.SetBool("walk", false);
                        animator.SetBool("run" , true);
                        if( transform.rotation== rotation) 
                        { 
                            transform.Translate(Vector3.forward*speed *2 * Time.deltaTime);
                        }
                        animator.SetBool("attack", false);
                        break;
                    case 2:
                        //flamethrower//
                        animator.SetBool("walk", false);
                        animator.SetBool("attack", true);
                        animator.SetBool("run", false); // chequear esto 
                        animator.SetFloat("skills", 0.8f);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        range.GetComponent<CapsuleCollider>().enabled = false;
                        break;
                    case 3:
                        //Jump Attack//
                        if ( fase == 2) 
                        {
                            jumpDistance += 1 * Time.deltaTime;
                            animator.SetBool("walk", false);
                            animator.SetBool("attack", true);
                            animator.SetBool("run", false);
                            animator.SetFloat("skills", 0.6f);
                            hitSelect = 3;
                            range.GetComponent<CapsuleCollider>().enabled = false;
                            if (directionSkill)
                            {
                                if (jumpDistance <1f)
                                {
                                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                                }
                                transform.Translate(Vector3.forward*8*Time.deltaTime);
                            }
                        }
                        else
                        {
                            routine= 0;
                            chronometer=0;
                        }
                        break;
                    case 4:
                        if ( fase == 2) 
                        {
                            animator.SetBool("walk", false);
                            animator.SetBool("attack", true);
                            animator.SetBool("run", false);
                            animator.SetFloat("skills", 1);
                            range.GetComponent<CapsuleCollider>().enabled = false;
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);
                        }
                        else
                        {
                            routine= 0;
                            chronometer= 0;
                        }
                        break;
                }
            }
        }
    }

    private void FinalAnimator()
    {
        routine= 0;
        animator.SetBool("attack", false);
        attack = false;
        range.GetComponent<CapsuleCollider>().enabled = true;
        flamethrower = false;
        jumpDistance= 0;
        directionSkill = false;
    }
    private void DirectionAttackStart()
    {
        directionSkill = true;
    }
    private void DirectionAttackFinal() 
    {
        directionSkill = false;
    }
    private void ColliderWeaponTrue()
    {
        hit[hitSelect].GetComponent<SphereCollider>().enabled = true;
    }
    private void ColliderWeaponFalse()
    {
        hit[hitSelect].GetComponent<SphereCollider>().enabled = false;
    }
    private GameObject GetBull()
    {
        for (int i = 0; i < pool.Count; i++) 
        {
            if (pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }
        GameObject obj = Instantiate(fire,head.transform.position,head.transform.rotation)as GameObject;
        pool.Add(obj);
        return obj;
    }
    private void FlamethrowerSkill()
    {
        chronometer2 += 1 * Time.deltaTime;
        if (chronometer2 > 0.1f) 
        { 
            GameObject obj= GetBull();
            obj.transform.position = head.transform.position;
            obj.transform.rotation = head.transform.rotation;
            chronometer2 = 0;

        }
    }
    private void StartFire()
    {
        flamethrower = true;
    }
    private void StopFire()
    {
        flamethrower = false;
    }
    /// fire ball ///
    /// 
    private GameObject GetFireBall() 
    { 
        for (int i = 0; i < pool2.Count; i++) // cheaquear esto
        {
            if (!pool2[i].activeInHierarchy)
            pool2[i].SetActive(true);
            return pool2[i];

        }
        GameObject obj = Instantiate(fireBall,point.transform.position,point.transform.rotation) as GameObject;
        pool2 .Add(obj);
        return obj;
    }
    private void FireBallSkill()
    {
        GameObject obj = GetFireBall();
        obj.transform.position = point.transform.position;
        obj.transform .rotation = point.transform.rotation;
    }
    private void life()
    {
        if (hpMax < 500)
        {
            fase = 2;
            timeRoutine= 1;
        }
        ControllerBoss();
        if (flamethrower)
        {
            FlamethrowerSkill();
        }
    }

    private void Update()
    {
        bar.fillAmount = hpMin / hpMax;
        
        if (hpMin > 0)
        {
            life();
        }
        else 
        {
            if (!dead)
            {
                animator.SetTrigger("dead");
                music.enabled = false;
                dead = true;
            }
        }
    } 



}
