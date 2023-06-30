using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShmupPlayerController : MonoBehaviour
{

    public bool gotKey;
    public int numCoins;
    public float rotation_speed;

    private PlayerActions m_playerActions;
    private Animator m_Animator;
    private MovementBehaviour m_MovementBehaviour;
    private ScreenBehaviour m_ScreenBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_MovementBehaviour = gameObject.GetComponent <MovementBehaviour>();
        m_playerActions = GetComponent<PlayerActions>();
        m_ScreenBehaviour = GetComponent<ScreenBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        InputUpdate();
    }

    void InputUpdate()
    {
        if (m_playerActions.moveValue.y != 0)
        {
            //if (m_ScreenBehaviour.CheckZPercentageMargin())
            //{
                m_MovementBehaviour.Move(transform.up * m_playerActions.moveValue.y);
            //}
            //m_Animator.SetInteger("State", 1);
        }
        if (m_playerActions.moveValue.x != 0)
        {
            if (m_ScreenBehaviour.CheckXPercentageMargin())
            {
                m_MovementBehaviour.Move(-transform.forward * m_playerActions.moveValue.x);
            }
            //m_Animator.SetInteger("State", 1);
        }
        if (m_playerActions.moveValue == Vector2.zero)
        {
            //m_Animator.SetInteger("State", 0);
        }
        //transform.Rotation += Vector3(0f, Time.deltaTime * rotation_speed * _playerActions.moveValue, 0f);
    }

    public void Shoot()
    {
        m_Animator.SetTrigger("Shoot");
        CreateBullet();
    }

    public void CreateBullet()
    {
        GetComponent<ShootBehaviour>().Shoot(transform.forward);
    }
}
