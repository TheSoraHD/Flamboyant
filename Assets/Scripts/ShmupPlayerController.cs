using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShmupPlayerController : MonoBehaviour
{

    public float rotation_speed;
    public Material material;

    private Animator m_Animator;
    private BulletPatternBehaviour m_BulletPatternBehaviour;
    private ColorBehaviour m_ColorBehaviour;
    private MovementBehaviour m_MovementBehaviour;
    private PlayerActions m_PlayerActions;
    private ScreenBehaviour m_ScreenBehaviour;

    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_BulletPatternBehaviour = GetComponent<BulletPatternBehaviour>();
        m_ColorBehaviour = gameObject.GetComponent<ColorBehaviour>();
        m_MovementBehaviour = gameObject.GetComponent <MovementBehaviour>();
        m_PlayerActions = gameObject.GetComponent<PlayerActions>();
        m_ScreenBehaviour = GetComponent<ScreenBehaviour>();
    }

    private void FixedUpdate()
    {
        MovementUpdateRB();
    }

    void Update()
    {
        ShootUpdate();
    }

    void MovementUpdateRB()
    {
        Vector3 dir = new(0,0,0);
        if (m_PlayerActions.moveValue.y != 0)
        {
            if (m_ScreenBehaviour.CheckYPercentageMargin(m_PlayerActions.moveValue.y))
                dir += -transform.forward * m_PlayerActions.moveValue.y;
                //m_MovementBehaviour.MoveRB(-transform.forward * m_PlayerActions.moveValue.y);
                //m_MovementBehaviour.Move(-transform.forward * m_PlayerActions.moveValue.y);
        }
        if (m_PlayerActions.moveValue.x != 0)
        {
            if (m_ScreenBehaviour.CheckXPercentageMargin(m_PlayerActions.moveValue.x))
            {
                dir += -transform.right * m_PlayerActions.moveValue.x;
                //m_MovementBehaviour.MoveRB(-transform.right * m_PlayerActions.moveValue.x);
                //m_MovementBehaviour.Move(-transform.right * m_PlayerActions.moveValue.x);
            }
        }
        m_MovementBehaviour.MoveRB(dir);
        if (m_PlayerActions.moveValue == Vector2.zero)
        {
            m_MovementBehaviour.StopMovementRB();
        }
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
