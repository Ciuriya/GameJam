using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
    [Tooltip("Unit's health")]
    public float m_health;

    [Tooltip("Only set if using health as a float variable.")]
    public FloatVariable m_refHealth;

    [Tooltip("Unit's max health")]
    public FloatReference m_maxHealth;

    [Tooltip("The time after taking damage where the unit is immune to damage.")]
    public float m_immunityWindow;
    private float m_lastHit;

    [Tooltip("Event called when the entity takes damage.")]
    public UnityEvent m_damageEvent;

    [Tooltip("Event called when the entity dies.")]
    public UnityEvent m_deathEvent;

    public bool IsImmune()
    {
        return Time.time * 1000 < m_lastHit + m_immunityWindow * 1000;
    }

    private float GetHealth()
    {
        return (m_refHealth) ? m_refHealth.Value : m_health;
    }

    private void SetHealth(float p_value)
    {
        if (m_refHealth) m_refHealth.Value = p_value;
        else m_health = p_value;
    }

    public void Damage(float p_amount)
    {
        SetHealth(GetHealth() - p_amount);
        m_lastHit = Time.time * 1000;

        m_damageEvent.Invoke();

        if (GetHealth() <= 0.0f)
            m_deathEvent.Invoke();
    }

    /*     --Created by Marko--
     Cause damage when starving aka when the player run out of food
     do not cause invulnerability frames and ignore them*/
    public void Starvation(float amount) 
    {
        SetHealth(GetHealth() - amount);
        if(GetHealth() <= 0f)
        {
            m_deathEvent.Invoke();
        }
    }

	void OnCollisionEnter2D(Collision2D p_collider)
	{
        if (p_collider.collider.CompareTag("Enemy")&& p_collider.otherCollider.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(p_collider.collider, p_collider.otherCollider);
            return;
        }

        if (p_collider.otherCollider.CompareTag("Player") || p_collider.collider.gameObject.layer != LayerMask.NameToLayer("Player")) return;
		if(p_collider.collider.CompareTag("Player") && p_collider.collider.GetComponent<UnitHealth>().IsImmune()) return;

       

		Damager damager = p_collider.otherCollider.GetComponent<Damager>();

		if(damager)
		{
			bool knockbackLeft = true;
			CharacterController2D cc2d = p_collider.collider.GetComponent<CharacterController2D>();

			if (cc2d)
			{
				knockbackLeft = cc2d.m_facingright ? true : false;
			}

			p_collider.collider.GetComponent<UnitHealth>().m_lastHit = Time.time * 1000;

			damager.HitCollider(p_collider.collider, p_collider.collider.GetComponent<Rigidbody2D>(), knockbackLeft);
		}
	}
}
