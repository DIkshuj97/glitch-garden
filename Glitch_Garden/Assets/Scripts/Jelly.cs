using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jelly : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        GameObject otherObject = othercollider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 81);
        }
        
    }

    private void OnTriggerExit2D(Collider2D othercollider)
    {
        GameObject otherObject = othercollider.gameObject;

        if (otherObject.GetComponent<Defender>())
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color32(255, 255, 255, 255);

        }
    }




}
