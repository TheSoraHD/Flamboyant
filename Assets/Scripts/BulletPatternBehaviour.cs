using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatternBehaviour : MonoBehaviour
{
    public enum BulletPatterns
    {
        Straigth,
        Circle
    };

    public BulletPatterns ChosenPatterns;

    public int numberOfProjectiles = 8;
    public float projectileSpeed = 1.0f;
    public float angleOffset = 0.0f;
    public float xPosStep = 0.5f;
    public float cooldown = 0.3f;
    private float currentCooldown = 0.0f;
    public GameObject ProjectilePrefab;

    private const float m_radius = 1.5f;
    private ColorBehaviour m_ColorBehaviour;
    private ShootBehaviour m_ShootBehaviour;

    void Start()
    {
        m_ColorBehaviour = GetComponent<ColorBehaviour>();
        m_ShootBehaviour = GetComponent<ShootBehaviour>();
    }

    void Update()
    {
        currentCooldown -= Time.deltaTime;
    }

    public void Shoot()
    {
        if (currentCooldown < 0.0f) {
            switch (ChosenPatterns)
            {
                case BulletPatterns.Straigth:
                    StraigthPattern();
                    break;
                case BulletPatterns.Circle:
                    CirclePattern();
                    break;
            }
            currentCooldown = cooldown;
        }
    }

    public void StraigthPattern()
    {
        float xPos = -xPosStep / 2.0f;
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            SpawnProjectile(xPos, 0.0f);
            xPos += xPosStep;
        }
    }

    public void CirclePattern()
    {
        float angleStep = 360.0f / numberOfProjectiles;
        float angle = angleOffset;
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            SpawnProjectile(0.0f, angle);
            angle += angleStep;
        }
    }

    private void SpawnProjectile(float xPos, float angle)
    {
        float projectileDirXPosition = Mathf.Sin((angle * Mathf.PI) / 180.0f) * m_radius;
        float projectileDirYPosition = Mathf.Cos((angle * Mathf.PI) / 180.0f) * m_radius;

        Vector3 projectileVector = new Vector3(projectileDirXPosition, 0.0f, projectileDirYPosition);
        Vector3 projectileMoveDirection = projectileVector.normalized * projectileSpeed;

        GameObject tmpObj = PoolingManager.Instance.GetPooledObject(ProjectilePrefab.name);
        tmpObj.tag = tag;
        tmpObj.SetActive(true);
        if (tmpObj.TryGetComponent<ColorBehaviour>(out ColorBehaviour color))
        {
            color.ChangeColor((int)m_ColorBehaviour.CurrentColor);
        }
        tmpObj.transform.SetParent(transform);
        //tmpObj.transform.position = new Vector3(transform.position.x + m_radius, transform.position.y, transform.position.z);
        tmpObj.transform.position = transform.position - (transform.forward * m_radius);
        tmpObj.transform.rotation = transform.rotation;
        tmpObj.GetComponent<Rigidbody>().velocity = -transform.forward * projectileSpeed;
    }
}
