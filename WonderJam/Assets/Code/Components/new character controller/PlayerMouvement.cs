using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour

    {
    private SpriteRenderer spriteRenderer;
    public Animator animator;

    public float halfjump;

    public Rigidbody2D m_rigidbody2d;

    public CharacterController2D Controller;

    float horizontalMove = 1f;

    public float runspeed = 40f;

    public float Direction;

	private Damager m_damager;

	void Awake()
	{
		m_damager = GetComponent<Damager>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update ()
{

        horizontalMove = (Input.GetAxisRaw("Horizontal") * runspeed );

		bool jumpReady = Time.time * 1000 > Controller.lastLanding + (Controller.jumpCooldown * 1000);

               
       animator.SetFloat("speed", Mathf.Abs (m_rigidbody2d.velocity.x) );
        
      


        if (Input.GetButtonDown("Jump") && jumpReady)
        {

			Controller.jump = true;

            animator.SetBool("isjumping", true);

        }
        else if(Input.GetButtonUp("Jump")&&(!Controller.jumprelease) && m_rigidbody2d.velocity.y > 0)
        {
			if (m_rigidbody2d.velocity.y > 0)
			{
				m_rigidbody2d.velocity = new Vector2(m_rigidbody2d.velocity.x, m_rigidbody2d.velocity.y / halfjump);

				Controller.jumprelease = true;
			}
        }

		if (Input.GetButton("Fire1") && m_damager)
		{
			if (m_damager.Damage())
				animator.SetBool("isattacking", true);
		}
		else if (Input.GetButtonUp("Fire1") && m_damager)
			animator.SetBool("isattacking", false);

	}



    // Update is called once per frame
    private void FixedUpdate()
    {

        Controller.Move(horizontalMove * Time.fixedDeltaTime);
		Controller.jump = false;

    }

}

