using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShmupLevelPlaneController : MonoBehaviour
{

    private MovementBehaviour m_movementBehaviour;

    private void Start()
    {
        m_movementBehaviour = GetComponent<MovementBehaviour>();
    }

    private void Update()
    {
        m_movementBehaviour.Move();
    }

}
