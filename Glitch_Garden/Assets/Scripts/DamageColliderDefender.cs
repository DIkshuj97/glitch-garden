using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageColliderDefender : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        Destroy(othercollider.gameObject);
    }
}
