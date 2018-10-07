using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PhysicsObject
{
    public FloatReference jumpSpeed;
    public FloatReference maxSpeed;
    public Animator animator;
    private float Direction;
    private float attacc;
    private SpriteRenderer spriterenderer;
	private Damager m_damager;
	private Vector2 m_knockback = Vector2.zero;

	void Awake()
	{
		m_damager = GetComponent<Damager>();
		spriterenderer = GetComponent<SpriteRenderer>();
	}

	public void Knockback(Vector2 p_knockback)
	{
		m_knockback = p_knockback;
	}

    protected override void ComputeVelocity()
    {
       
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpSpeed.Value;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)velocity.y *= 0.5f;
        }

		if (Mathf.Abs(m_knockback.x) + Mathf.Abs(m_knockback.y) >= 0.5f)
		{
			move = m_knockback;
			m_knockback = new Vector2(m_knockback.x / 1.2f, m_knockback.y / 1.2f);
		}

        targetVelocity = move * maxSpeed.Value;

        // Hook with Animator

        Direction = Input.GetAxisRaw("Horizontal");

        if(Direction!=0)
        { 
            if(Direction==-1)
            {
                spriterenderer.flipX = true;
            }
            if (Direction == 1)
            {
                spriterenderer.flipX = false;
             }
        }

        animator.SetFloat("speed", Mathf.Abs (move.x));

        if (grounded == false)
        {
            animator.SetBool("isjumping", true);
        }
        else
            animator.SetBool("isjumping", false);

		if (Input.GetButtonDown("Fire1") && m_damager)
		{
			if (m_damager.Damage())
				animator.SetBool("isattacking", true);
		} else if (Input.GetButtonUp("Fire1") && m_damager)
			animator.SetBool("isattacking", false);
    }
}