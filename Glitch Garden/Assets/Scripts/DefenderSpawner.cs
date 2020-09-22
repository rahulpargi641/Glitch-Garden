using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
     Defender defender;
    Vector2 lastPos;


    public void SetDefenderPrefab(Defender defenderPrefab)
    {
        defender = defenderPrefab;
    }

    private void OnMouseDown()
    {
        Debug.Log("Button Was Clicked");
        AttemptToPlaceAt(GetSqureClicked());
    }

    void AttemptToPlaceAt(Vector2 gridPos)
    {
        if (lastPos != gridPos)
        {
        lastPos = gridPos;

            int defenderCost = defender.GetStarCost();
            var StarDisplay = FindObjectOfType<StarDisply>();

            if (StarDisplay.HaveEnoughStars(defenderCost))
            {
                StarDisplay.SpendStars(defenderCost);
                SpawnDefender(gridPos);
            }
        }
        else
        {

            Debug.Log("Already Placed");

        }



    }

    private Vector2 GetSqureClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = new Vector2( Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Debug.Log (worldPos);
        Vector2 gridPos =SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPoint)
    {
        int newX = Mathf.RoundToInt(rawWorldPoint.x);
        int newY= Mathf.RoundToInt(rawWorldPoint.y);
        Debug.Log(newY);
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 clickPoint)
    {
        
        Defender newDefender = Instantiate(defender, clickPoint, Quaternion.identity) as Defender;
    }
  
}
