using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        if(!defender) { return; }
        AttemptToPlaceDefender();
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);               // Get mouse position
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);                                // Convert to World position
        Vector2 snapPos = new Vector2(Mathf.RoundToInt(worldPos.x), Mathf.RoundToInt(worldPos.y));  // Snap to Grid
        return snapPos;
    }

    private void SpawnDefender()
    {
        Defender newDefender = Instantiate(defender, GetSquareClicked(), Quaternion.identity) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefender()
    {
        var coinDisplay = FindObjectOfType<CoinDisplay>();
        int defenderCost = defender.GetCost();
        if (coinDisplay.HaveEnoughCoins(defenderCost))
        {
            SpawnDefender();
            coinDisplay.SpendCoins(defenderCost);
        }
    }
}
