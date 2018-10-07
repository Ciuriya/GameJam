using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour

    {

    public bool jumprelease =false;

    public float HalfJump;

    public Rigidbody2D m_RigidBody2d;

    public CharacterController2D controller;

    float horizontalmove = 1f;

    public float RunSpeed = 40f;

    bool Jump = false;

	// Update is called once per frame
void Update ()
{

        horizontalmove = (Input.GetAxisRaw("Horizontal") * RunSpeed);



        if (Input.GetButtonDown("Jump"))
        {

            Jump = true;
           

        }
        else if(Input.GetButtonUp("Jump")&&(!controller.jumprelease))
        {

            m_RigidBody2d.velocity = new Vector2(0f, m_RigidBody2d.velocity.y / HalfJump);

            controller.jumprelease = true;
         
        }
    
}



    // Update is called once per frame
    void FixedUpdate()
    {

        controller.Move(horizontalmove * Time.fixedDeltaTime, Jump);
        Jump = false;

    }

}

