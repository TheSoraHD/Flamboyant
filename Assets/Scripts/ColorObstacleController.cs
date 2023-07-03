using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorObstacleController : MonoBehaviour
{

    private ColorBehaviour m_colorBehaviour;
    private DestroyBehaviour m_destroyBehaviour;

    private void Start()
    {
        m_colorBehaviour = GetComponent<ColorBehaviour>();
        m_destroyBehaviour = GetComponent<DestroyBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ColorBehaviour>(out ColorBehaviour color))
        {
            ColorBehaviour.ColorEnum otherColor = color.CurrentColor; //we have to grab it before destroying the object
            other.GetComponent<DestroyBehaviour>().DestroyObject();
            if (otherColor == m_colorBehaviour.CurrentColor)
            {
                m_destroyBehaviour.DestroyObject();
            }
        }
    }
}
