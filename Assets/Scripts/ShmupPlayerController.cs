using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShmupPlayerController : MonoBehaviour
{

    public float rotation_speed;

    private Animator m_Animator;
    private BulletPatternBehaviour m_BulletPatternBehaviour;
    private ColorBehaviour m_ColorBehaviour;
    private MovementBehaviour m_MovementBehaviour;
    private PlayerActions m_PlayerActions;
    private ScreenBehaviour m_ScreenBehaviour;

    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_BulletPatternBehaviour = GetComponent<BulletPatternBehaviour>();
        m_ColorBehaviour = GetComponent<ColorBehaviour>();
        m_MovementBehaviour = GetComponent <MovementBehaviour>();
        m_PlayerActions = GetComponent<PlayerActions>();
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
        }
        if (m_PlayerActions.moveValue.x != 0)
        {
            if (m_ScreenBehaviour.CheckXPercentageMargin(m_PlayerActions.moveValue.x))
                dir += -transform.right * m_PlayerActions.moveValue.x;
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
        m_BulletPatternBehaviour.Shoot();
    }
}
