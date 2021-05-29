using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] GameObject deathVFX;

    //method to show damage
    public void DealDamage(float damage)
    {
        health-=damage;

        if(health<=0)
        {
           TriggerDeathVFX();
           Destroy(gameObject); //gameobject will destroyed after zero health
        }
    }

     
    private void TriggerDeathVFX()
    {
      if (!deathVFX) { return; }
      GameObject deathVFXObject= Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(deathVFXObject, 1f);
    }
}

