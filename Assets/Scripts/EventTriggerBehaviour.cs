using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTriggerBehaviour : MonoBehaviour
{
    public GameObject Player;
    public UnityEvent OnTouch;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
            OnTouch.Invoke();
    }
}
