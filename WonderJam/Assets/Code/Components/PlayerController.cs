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
    public SpriteRenderer spriterenderer;
	public Damager m_damager;

	void Awake()
	{
		m_damager = GetComponent<Damager>();
		spriterenderer = GetComponent<SpriteRenderer>();
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
			if(m_damager.Damage())
				animator.SetBool("isattacking", true);

        }
        else if (Input.GetButtonUp("Fire1") && m_damager)
        {
            animator.SetBool("isattacking", false);
        }
    }
}
