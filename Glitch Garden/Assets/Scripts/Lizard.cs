using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Attackers))]
public class Lizard : MonoBehaviour
{
    private Animator anim;
    private Attackers attacker;
    
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        attacker = gameObject.GetComponent<Attackers>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (obj.GetComponent<Defenders>())
        {
            anim.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        }
        else
        {
            return;
        }
    }
}
