using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinDisplay : MonoBehaviour
{
    [SerializeField] int coins = 100;
    Text coinText;

    private void Start()
    {
        coinText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        coinText.text = coins.ToString();
    }

    public void AddCoins(int ammount)
    {
        coins += ammount;
        UpdateDisplay();
    }

    public void SpendCoins(int ammount)
    {
        if(ammount <= coins)
        {
            coins -= ammount;
            UpdateDisplay();
        }
    }
}
