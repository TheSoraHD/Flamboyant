using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
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

    public void Rotate(float rotationSpeed)
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

}
