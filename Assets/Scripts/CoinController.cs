using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using System;

public class CoinController : MonoBehaviour
{
    public int numCoins = 0;
    public UnityEvent<int> OnUpdateTextCoin;

    private void OnEnable()
    {
        CoinTextUpdater.OnUpdateCoin += IncCoins;
    }

    private void OnDisable()
    {
        CoinTextUpdater.OnUpdateCoin -= IncCoins;
    }
    public void IncCoins(int value)
    {
        numCoins += value;
        OnUpdateTextCoin.Invoke(numCoins);
    }

    public void DecCoins(int value)
    {
        numCoins -= value;
        OnUpdateTextCoin.Invoke(numCoins);
    }

    public void ZeroCoins()
    {
        numCoins = 0;
        OnUpdateTextCoin.Invoke(numCoins);
    }
}
