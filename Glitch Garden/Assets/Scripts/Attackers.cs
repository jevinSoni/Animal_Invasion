using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class Attackers : MonoBehaviour
{
    public float seenEverySeconds;
    private float currentSpeed;
    private Animator anim;
    private GameObject currentTarget;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }
    
    void Update()
    {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        if(!currentTarget)
        {
            anim.SetBool("IsAttacking", false);
        }
    }
    
    public void setSpeed(float speed)
    {
        currentSpeed = speed; 
    }
    public void StrikeCurrentTarget(float damage)
    {
        if(currentTarget)
        {
            Health health= currentTarget.GetComponent<Health>();
            if(health)
            {
                health.DealDamage(damage);
            }
        }
    }
    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }

}
