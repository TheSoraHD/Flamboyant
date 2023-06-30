using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private MovementBehaviour m_movementBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        m_movementBehaviour = GetComponent<MovementBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        m_movementBehaviour.Move();
    }
}
