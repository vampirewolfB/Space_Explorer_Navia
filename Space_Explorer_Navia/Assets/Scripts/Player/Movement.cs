using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D m_Rb;
    GroundChecker m_GroundChecker;
    DoubleJumpCheck temp;

    [SerializeField] float m_HorizontalMovement;
    [SerializeField] float m_HorizontalSpeed;
    [SerializeField] float m_JumpHeight;
    bool m_Jumped;
    bool doubleJump;

    // Start is called before the first frame update
    void Start()
    {
        m_Rb = GetComponent<Rigidbody2D>();
        m_GroundChecker = GetComponentInChildren<GroundChecker>();
        temp = GetComponent<DoubleJumpCheck>();
    }

    // Update is called once per frame
    void Update()
    {
        m_HorizontalMovement = Input.GetAxis("Horizontal");

        if (!Input.GetKeyDown(KeyCode.Space) && m_GroundChecker.m_IsGrounded)
        {
            doubleJump = false;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
           if (m_GroundChecker.m_IsGrounded || doubleJump)
           {
                m_Jumped = true;
                if (temp.HasDoubleJump)
                {
                    doubleJump = !doubleJump;
                }
           }
        }
    }

    private void FixedUpdate()
    {
        //physics
        m_Rb.velocity = new Vector2(m_HorizontalMovement * m_HorizontalSpeed, m_Rb.velocity.y);
        if (m_Jumped)
        {
            m_Rb.velocity = new Vector2(m_Rb.velocity.x, m_JumpHeight);
            m_Jumped = false;
        }
    }
}
