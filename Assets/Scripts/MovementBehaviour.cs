using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float rotationZLimit;
    public Vector3 direction;

    private float m_auxspeed;
    private Rigidbody m_rb;

    private void Start()
    {
        if (!TryGetComponent<Rigidbody>(out m_rb))
            m_rb = null;
    }

    public void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }
    public void SetSpeed(float s)
    {
        speed = s;
    }

    public void SetDirection(Vector3 d)
    {
        direction = d;
    }

    public void Move()
    {
        transform.position += direction * Time.deltaTime * speed;
    }

    public void Move(Vector3 dir)
    {
        transform.position += dir * Time.deltaTime * speed;
    }

    public void Move(Vector3 dir, float speed)
    {
        transform.position += dir * Time.deltaTime * speed;
    }

    public void MoveLocal()
    {
        transform.localPosition += direction * Time.deltaTime * speed;
    }

    public void MoveLocal(Vector3 dir)
    {
        transform.localPosition += dir * Time.deltaTime * speed;
    }

    public void MoveLocal(Vector3 dir, float speed)
    {
        transform.localPosition += dir * Time.deltaTime * speed;
    }

    public void MoveRB()
    {
        m_rb.velocity = direction * speed;
    }

    public void MoveRB(Vector3 dir)
    {
        m_rb.velocity = dir * speed;
    }

    public void MoveRB(Vector3 dir, float speed)
    {
        m_rb.velocity = dir * speed;
    }

    public void Rotate()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

    public void RotateZ(float moveValue)
    {
        if (moveValue > 0.0f && transform.rotation.z < rotationZLimit)
            transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    public void StopMovement()
    {
        m_auxspeed = speed;
        speed = 0;
    }

    public void RestoreMovement()
    {
        speed = m_auxspeed;
    }

    public void StopMovementRB()
    {
        m_rb.velocity = Vector3.zero;
    }

}
