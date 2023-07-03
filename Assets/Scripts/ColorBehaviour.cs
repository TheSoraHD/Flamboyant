using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBehaviour : MonoBehaviour
{
    private MeshRenderer m_MeshRenderer;

    public List<Material> mats = new List<Material>();

    void Start()
    {
        m_MeshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public void ChangeColor()
    {
        m_MeshRenderer.material = mats[0];
    }

    public void ChangeColor(int id)
    {
        m_MeshRenderer.material = mats[id];
    }

    public void ChangeColor(MeshRenderer mesh)
    {
        setMeshRenderer(mesh);
        ChangeColor();
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

}
