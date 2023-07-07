using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<HealthBehaviour>().Hurt(1);
            other.GetComponent<DestroyBehaviour>().StartDeactivation();
        }
    }
}
