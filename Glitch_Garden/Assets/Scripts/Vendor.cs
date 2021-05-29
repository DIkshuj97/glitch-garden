using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    
    [SerializeField] float damage = 500f;
    [SerializeField] float speed=0f;

    private void Update()
    {
        if(GetComponent<Animator>().GetBool("Running"))
        {
            Move();
        }
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;

        if(otherObject.GetComponent<Attacker>())
        {
            GetComponent<Animator>().SetBool("Running", true);
            var health = otherCollider.GetComponent<Health>();
            var attacker = otherCollider.GetComponent<Attacker>();
            if (attacker && health)
            {
                health.DealDamage(damage); 
            }
        }
    }

    private void Move()
    {
        transform.Translate(Vector2.right * Time.deltaTime);
    }
}
