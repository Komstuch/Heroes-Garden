using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] float cost;

    public void AddCoins(int coins)
    {
        FindObjectOfType<CoinDisplay>().AddCoins(coins);
        GetComponentInChildren<CoinSpark>().Spark(); // Play spark vfx
    }
}
