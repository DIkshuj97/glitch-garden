using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile,gun;
    GameObject projectileparent;
    const string PROJECTILE_PARENT_NAME = "Projectiles";

    AttackerSpawner myLaneSpawner;
    Animator animator;

    private void Start()
    {
        SetLaneSpawner();
       animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

    private void CreateProjectileParent()
    {
        projectileparent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (!projectileparent)
        {
            projectileparent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    private void Update()
    {
        if(IsAttackerInLane())
        {
           animator.SetBool("isAttacking", true); 
        }

        else
        {
          animator.SetBool("isAttacking", false);
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);

            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    private bool IsAttackerInLane()
    {
        
        if(myLaneSpawner.transform.childCount <=0)
        {
            return false;
        }

        else
        {
            return true;
        }

    }

    //cloning of zuchinni (projectile) at gun(hand) position
    public void Fire()
    {
        GameObject newProjectile = Instantiate(projectile, gun.transform.position, transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileparent.transform;
    }
}
