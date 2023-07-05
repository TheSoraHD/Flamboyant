using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorObstacleController : MonoBehaviour
{

    private ColorBehaviour m_colorBehaviour;
    private DestroyBehaviour m_destroyBehaviour;
    private MovementBehaviour m_movementBehaviour;

    private void Start()
    {
        m_colorBehaviour = GetComponent<ColorBehaviour>();
        m_destroyBehaviour = GetComponent<DestroyBehaviour>();
        m_movementBehaviour = GetComponent<MovementBehaviour>();
    }

    private void Update()
    {
        m_movementBehaviour.MoveLocal();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ColorBehaviour>(out ColorBehaviour color))
        {
            ColorBehaviour.ColorEnum otherColor = color.CurrentColor; //we have to grab it before destroying/deactivating the object
            other.GetComponent<DestroyBehaviour>().StartDeactivation();
            if (otherColor == m_colorBehaviour.CurrentColor)
            {
                m_destroyBehaviour.DestroyObject();
            }
        }
    }
}
