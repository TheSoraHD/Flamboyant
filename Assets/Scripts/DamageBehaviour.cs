using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBehaviour : MonoBehaviour
{
    public float damage;
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tag) && other.gameObject.TryGetComponent<HealthBehaviour>(out HealthBehaviour h))
            h.Hurt(damage);
    }
}
