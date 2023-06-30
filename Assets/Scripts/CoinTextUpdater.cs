using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTextUpdater : MonoBehaviour
{
    public int value;
    public static event Action<int> OnUpdateCoin = delegate{};

    public void OnUpdateText()
    {
        OnUpdateCoin.Invoke(value);
    }
}
