using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayerController : MonoBehaviour
{

    public bool gotKey;
    public int numCoins;
    public float rotation_speed;

    private PlayerActions m_playerActions;
    private Animator m_Animator;
    private MovementBehaviour m_MovementBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = gameObject.GetComponent<Animator>();
        m_MovementBehaviour = gameObject.GetComponent <MovementBehaviour>();
        m_playerActions = GetComponent<PlayerActions>();
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
            m_MovementBehaviour.Move(transform.forward * m_playerActions.moveValue.y);
            m_Animator.SetInteger("State", 1);
        }
        if (m_playerActions.moveValue.x != 0)
        {
            m_MovementBehaviour.Rotate(rotation_speed * m_playerActions.moveValue.x);
        }
        if (m_playerActions.moveValue == Vector2.zero)
        {
            m_Animator.SetInteger("State", 0);
        }
        //transform.Rotation += Vector3(0f, Time.deltaTime * rotation_speed * _playerActions.moveValue, 0f);
    }

    public void Shoot()
    {
        m_Animator.SetTrigger("Shoot");
    }

    public void CreateBullet()
    {
        GetComponent<ShootBehaviour>().Shoot(-transform.right);
    }
}
