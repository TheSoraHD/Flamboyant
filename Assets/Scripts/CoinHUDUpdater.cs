using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinHUDUpdater : MonoBehaviour
{
    public void UpdateTextCoins(int coins)
    {
        GetComponent<TMP_Text>().text = "Coins: " + coins;
    }
}
