using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShmupEnemy : MonoBehaviour
{
    private BulletPatternBehaviour m_bulletPatternBehaviour;
    private ColorBehaviour m_colorBehaviour;
    private DestroyBehaviour m_destroyBehaviour;
    private HealthBehaviour m_healthBehaviour;
    private MovementBehaviour m_movementBehaviour;

    public Transform Player;

    private void Start()
    {
        m_bulletPatternBehaviour = GetComponent<BulletPatternBehaviour>();
        m_colorBehaviour = GetComponent<ColorBehaviour>();
        m_destroyBehaviour = GetComponent<DestroyBehaviour>();
    }

    private void FixedUpdate()
    {
        transform.LookAt(Player);
    }

    private void Update()
    {
        m_bulletPatternBehaviour.Shoot();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<ColorBehaviour>(out ColorBehaviour color))
        {
            ColorBehaviour.ColorEnum otherColor = color.CurrentColor; //we have to grab it before destroying/deactivating the object
            other.GetComponent<DestroyBehaviour>().StartDeactivation();
            if (otherColor == m_colorBehaviour.CurrentColor)
            {
                m_healthBehaviour.Hurt(1);
            }
        }
    }

}
