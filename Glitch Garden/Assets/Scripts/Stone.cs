using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public Animator animator;
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attackers attackers = collision.gameObject.GetComponent<Attackers>();
        if(attackers)
        {
            animator.SetTrigger("underAttackeTriger");
        }
    }
}
