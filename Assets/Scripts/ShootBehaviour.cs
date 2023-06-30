using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehaviour : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bullet;

    public void Shoot(Vector3 dir)
    {
        GameObject shot = PoolingManager.Instance.GetPooledObject();
        if (shot != null)
        {
            shot.transform.position = shootingPoint.position;
            shot.transform.rotation = shootingPoint.rotation;
            shot.SetActive(true);
            shot.GetComponent<Rigidbody2D>().AddForce(dir);
        }
    }
}
