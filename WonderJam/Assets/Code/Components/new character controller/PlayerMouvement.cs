using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour

    {
    public SpriteRenderer spriteRenderer;
    public Animator animator;

    public bool jumprelease =false;

    public float halfjump;

    public Rigidbody2D m_rigidbody2d;

    public CharacterController2D Controller;

    float horizontalMove = 1f;

    public float runspeed = 40f;

    bool jump = false;

    public float Direction;

	// Update is called once per frame
void Update ()
{

        horizontalMove = (Input.GetAxisRaw("Horizontal") * runspeed );

  
     

        if (Input.GetButtonDown("Jump"))
        {

            jump = true;
           

        }
        else if(Input.GetButtonUp("Jump")&&(!Controller.jumprelease))
        {

            m_rigidbody2d.velocity = new Vector2(0f, m_rigidbody2d.velocity.y / halfjump);

           

            Controller.jumprelease = true;
         
        }
    
}



    // Update is called once per frame
    private void FixedUpdate()
    {

        Controller.Move(horizontalMove * Time.fixedDeltaTime, jump);
        jump = false;

    }

}

