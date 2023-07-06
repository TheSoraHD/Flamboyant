using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerController : MonoBehaviour
{
    public enum ColorEnum
    {
        RED,
        GREEN,
        BLUE,
        PURPLE
    };

    public ColorEnum ColorToChange;

    private ColorBehaviour m_colorBehaviour;
    private MovementBehaviour m_movementBehaviour;

    private void Start()
    {
        m_colorBehaviour = GetComponent<ColorBehaviour>();
        m_movementBehaviour = GetComponent<MovementBehaviour>();
    }

    private void Update()
    {
        if (m_movementBehaviour != null)
        {
            m_movementBehaviour.MoveLocal();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ColorBehaviour>(out ColorBehaviour color))
        {
            color.ChangeColor((int)ColorToChange);
        }
    }
}
