using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorCubeController : MonoBehaviour
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

    private void Start()
    {
        m_colorBehaviour = GetComponent<ColorBehaviour>();
    }

    private void OnTriggerEnter(Collider other)
    {
        MeshRenderer mesh = other.gameObject.GetComponent<MeshRenderer>();
        m_colorBehaviour.ChangeColor(mesh, ((int)ColorToChange));
    }
}
