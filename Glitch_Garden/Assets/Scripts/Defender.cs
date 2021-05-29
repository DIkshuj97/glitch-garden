using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starcost = 100;

    public int GetStarCost()
    {
        return starcost;
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().addStars(amount);
    }
}
