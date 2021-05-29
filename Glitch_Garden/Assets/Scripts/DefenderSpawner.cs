using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderparent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreatedefenderParent();
    }

    private void CreatedefenderParent()
    {
        defenderparent = GameObject.Find(DEFENDER_PARENT_NAME);
        if (!defenderparent)
        {
            defenderparent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        AttemptToplaceDefenderAt(GetSquareClicked());
    }

    

    public void SetselectDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToplaceDefenderAt(Vector2 gridpos)
    {
        if (defender == null)
        {
            return;
        }

        var stardisplay = FindObjectOfType<StarDisplay>();
        int defendercost = defender.GetStarCost();
        
        if (stardisplay.HaveEnoughStars(defendercost))
        {
            spawnDefender(gridpos);
            stardisplay.spendStars(defendercost);
        }
    }

    //to store the coordinated of mouse pointer
    private Vector2 GetSquareClicked()
    {
        Vector2 clickpos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldpos = Camera.main.ScreenToWorldPoint(clickpos);
        Vector2 gridpos = SnapToGrid(worldpos);
        return gridpos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldpos)
    {
        float newX = Mathf.RoundToInt(rawWorldpos.x);
        float newY = Mathf.RoundToInt(rawWorldpos.y);
        return new Vector2(newX, newY);
    }

    private void spawnDefender(Vector2 roundedpos)
    {
        Defender newdefender = Instantiate(defender, roundedpos, Quaternion.identity) as Defender;
        newdefender.transform.parent = defenderparent.transform;
    }


}
