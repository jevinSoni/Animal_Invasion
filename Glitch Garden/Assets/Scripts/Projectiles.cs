using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
    public float speed;
    public float damage;

    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attackers attacker=collision.gameObject.GetComponent<Attackers>();
        Health health = collision.gameObject.GetComponent<Health>();
        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
        if(collision.name=="Shredder")
        {
            Destroy(gameObject);
        }
    }
}
