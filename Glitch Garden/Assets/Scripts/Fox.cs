using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Attackers))]
public class Fox : MonoBehaviour
{
    Animator anim;
    Attackers attacker;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        attacker = gameObject.GetComponent<Attackers>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;
        if (!obj.GetComponent<Defenders>())
        {
            return;
        }
        if (obj.GetComponent<Stone>())
        {
            anim.SetTrigger("Jump Trigger");
        }
        else
        {
            anim.SetBool("IsAttacking", true);
            attacker.Attack(obj);
        }
    }
}
