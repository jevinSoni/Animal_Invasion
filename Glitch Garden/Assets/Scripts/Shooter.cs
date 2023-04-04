using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectiles, Gun;
    private Animator animator;
    private GameObject projectileParent;
    private AttackerSpawner myLaneSpawner;
    public AttackerSpawner[] spawnArray;
    private void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();

        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        SetMyLaneSpawner();
    }
    private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
    private void SetMyLaneSpawner()
    {
        spawnArray = GameObject.FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner Spawner in spawnArray)
        {
            float spawnerPosY = Spawner.transform.position.y;
            spawnerPosY = Mathf.RoundToInt(Spawner.transform.position.y);

            if (spawnerPosY== transform.position.y)
            {
                myLaneSpawner = Spawner;
                return;
            }
        }
        Debug.Log("Can't Find Spawner");

    }
    private void Fire()
    {
        GameObject newprojectiles = Instantiate(projectiles);
        newprojectiles.transform.parent = projectileParent.transform;
        newprojectiles.transform.position = Gun.transform.position;
        
    }
    private bool IsAttackerInLane()            //cheking if attacker is on the path
    {
        if(myLaneSpawner.transform.childCount<=0)
        {
            return false;
        }
        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if(attacker.transform.position.x>transform.position.x)
            {
                return true;
            }
        }
        return true;
    }
    
    
}
