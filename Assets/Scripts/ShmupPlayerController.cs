using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShmupPlayerController : MonoBehaviour
{

    public float rotation_speed;

    private PlayerActions m_PlayerActions;
    private Animator m_Animator;
    private MovementBehaviour m_MovementBehaviour;
    private ScreenBehaviour m_ScreenBehaviour;
    private BulletPatternBehaviour m_BulletPatternBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_MovementBehaviour = gameObject.GetComponent <MovementBehaviour>();
        m_PlayerActions = GetComponent<PlayerActions>();
        m_ScreenBehaviour = GetComponent<ScreenBehaviour>();
        m_BulletPatternBehaviour = GetComponent<BulletPatternBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        MovementUpdate();
        ShootUpdate();
    }

    void MovementUpdate()
    {
        if (m_PlayerActions.moveValue.y != 0)
        {
            //if (m_ScreenBehaviour.CheckZPercentageMargin())
            //{
                m_MovementBehaviour.Move(-transform.forward * m_PlayerActions.moveValue.y);
            //}
            //m_Animator.SetInteger("State", 1);
        }
        if (m_PlayerActions.moveValue.x != 0)
        {
            if (m_ScreenBehaviour.CheckXPercentageMargin())
            {
                m_MovementBehaviour.Move(-transform.right * m_PlayerActions.moveValue.x);
            }
            //m_Animator.SetInteger("State", 1);
        }
        if (m_PlayerActions.moveValue == Vector2.zero)
        {
            //m_Animator.SetInteger("State", 0);
        }
        //transform.Rotation += Vector3(0f, Time.deltaTime * rotation_speed * _playerActions.moveValue, 0f);
    }

    void ShootUpdate()
    {
        if (m_PlayerActions.shootValue)
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        //m_Animator.SetTrigger("Shoot");
        m_BulletPatternBehaviour.SpawnProjectile();
        //CreateBullet();
    }

    public void CreateBullet()
    {
        //m_ShootBehaviour.Shoot(transform.forward);
    }
}
