using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D:MonoBehaviour
{
    [SerializeField] public float m_jumpforce = 400f;
    [Range(0, 3f)] [SerializeField] private float m_mouvementsmoothing = 0.05f;
    [SerializeField] private bool m_aircontrol = false;
    [SerializeField] private LayerMask m_whatisground;
    [SerializeField] private Transform m_groundcheck;

    const float k_groundedradius = .2f;
    private bool m_grounded;
    private Rigidbody2D m_rigidbody2D;
    private bool m_facingright = true;
    private Vector3 m_velocity = Vector3.zero;

    public bool jumprelease;


    public SpriteRenderer spriterenderer;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandevent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Awake()
    {
        m_rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandevent == null) 
        {
            OnLandevent = new UnityEvent();
        }

    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_grounded ;
        m_grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_groundcheck.position, k_groundedradius, m_whatisground);

        for(int i=0;i<colliders.Length;i++)
        {
            if(colliders[i].gameObject!=gameObject)
            {

                m_grounded = true;
                if (!wasGrounded)
                {
                    OnLandevent.Invoke();


                    jumprelease = false;


                }
                    






            }

        }

    }

    public void Move(float move,bool jump)
    {


        if(m_grounded || m_aircontrol)
        {

            Vector3 targetVelocity = new Vector2(move * 10f, m_rigidbody2D.velocity.y);

            m_rigidbody2D.velocity = Vector3.SmoothDamp(m_rigidbody2D.velocity, targetVelocity, ref m_velocity, m_mouvementsmoothing);

            
            if (move > 0 && !m_facingright)
            {
                
                Flip();
            }
            
            else if (move < 0 && m_facingright)
            {
                
                Flip();
            }

        }

       if(m_grounded && jump)
        {

            m_grounded = false ;
            m_rigidbody2D.AddForce(new Vector2(0f, m_jumpforce));

        }

    }



    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_facingright = !m_facingright;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;


    }

}
