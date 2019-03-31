using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int cost;

    [SerializeField] bool isStatic;

    public void AddCoins(int coins)
    {
        FindObjectOfType<CoinDisplay>().AddCoins(coins);
        GetComponentInChildren<CoinSpark>().Spark(); // Play spark vfx
    }

    public int GetCost() { return cost; }

    public bool GetStatic() { return isStatic; }
}
