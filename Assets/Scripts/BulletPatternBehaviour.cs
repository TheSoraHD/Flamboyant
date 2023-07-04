using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternBehaviour : MonoBehaviour
{

    public int numberOfProjectiles = 8;
    public float projectileSpeed = 1.0f;
    public GameObject ProjectilePrefab;

    private const float m_radius = 1.0f;
    private ShootBehaviour m_ShootBehaviour;

    void Start()
    {
        m_ShootBehaviour = GetComponent<ShootBehaviour>();
    }

    public void SpawnProjectile()
    {
        float angleStep = 360.0f / numberOfProjectiles;
        float angle = 0.0f;

        for (int i = 0; i < numberOfProjectiles - 1; i++)
        {
            float projectileDirXPosition = Mathf.Sin((angle * Mathf.PI) / 180.0f) * m_radius;
            float projectileDirYPosition = Mathf.Cos((angle * Mathf.PI) / 180.0f) * m_radius;

            Vector3 projectileVector = new Vector3(projectileDirXPosition, projectileDirYPosition, 0.0f);
            Vector3 projectileMoveDirection = projectileVector.normalized * projectileSpeed;

            //GameObject tmpObj = Instantiate(ProjectilePrefab, transform.position, Quaternion.identity);
            GameObject tmpObj = PoolingManager.Instance.GetPooledObject(ProjectilePrefab.name);
            print(tmpObj.name);
            tmpObj.SetActive(true);
            tmpObj.transform.position = new Vector3(transform.position.x + m_radius, transform.position.y , transform.position.z);
            tmpObj.GetComponent<Rigidbody>().velocity = new Vector3(projectileMoveDirection.x, 0, projectileMoveDirection.y);

            angle += angleStep;
        }
    }
}
