using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour
{
    public enum ColorEnum
    {
        RED,
        GREEN,
        BLUE,
        PURPLE
    };

    public ColorEnum CurrentColor = ColorEnum.RED;
    public int matID = 0;
    public List<Material> mats = new List<Material>();

    private MeshRenderer m_MeshRenderer;

    private void Awake()
    {
        m_MeshRenderer = GetComponent<MeshRenderer>();
    }

    public void ChangeColor()
    {
        ChangeColor((int)CurrentColor);
    }

    public void ChangeColor(int id)
    {
        m_MeshRenderer.material = mats[id];
        setCurrentColor(id);
    }

    public void ChangeColor(MeshRenderer mesh)
    {
        ChangeColor(mesh, 0);
    }

    public void ChangeColor(MeshRenderer mesh, int id)
    {
        setMeshRenderer(mesh);
        ChangeColor(id);
    }

    private void setMeshRenderer(MeshRenderer mesh)
    {
        m_MeshRenderer = mesh;
    }

    private void setCurrentColor(int id)
    {
        CurrentColor = (ColorEnum)id;
    }

}
