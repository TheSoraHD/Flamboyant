using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthTextUpdater : MonoBehaviour
{
    public void UpdateTextHealth(float health)
    {
        string t = GetComponent<TMP_Text>().text = "Health: " + health;
    }
}
