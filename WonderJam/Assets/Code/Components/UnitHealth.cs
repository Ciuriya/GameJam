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
	private Collider2D m_immuneOnNextCollision;

	[Tooltip("Event called when the entity takes damage.")]
	public UnityEvent m_damageEvent;

	[Tooltip("Event called when the entity dies.")]
	public UnityEvent m_deathEvent;

	public bool IsImmune()
	{
		return Time.time * 1000 < m_lastHit + m_immunityWindow * 1000;
	}

	public void SetImmunityToNextCollision(Collider2D p_immuneToCollider)
	{
		m_immuneOnNextCollision = p_immuneToCollider;
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

		if(GetHealth() <= 0.0f)
			m_deathEvent.Invoke();
	}

	void OnCollisionEnter2D(Collision2D p_collider)
	{
		if(tag == p_collider.collider.tag || IsImmune() || p_collider.collider.CompareTag("Player")) return;

		if (m_immuneOnNextCollision == p_collider.collider)
		{
			m_immuneOnNextCollision = null;
			return;
		}

		Damager damager = p_collider.collider.GetComponent<Damager>();

		if(damager)
		{
			UnitHealth damagedHealth = p_collider.otherCollider.GetComponent<UnitHealth>();
			if (damagedHealth) damagedHealth.SetImmunityToNextCollision(p_collider.collider);

			bool reverseKnockback = true;
			SpriteRenderer renderer = GetComponent<SpriteRenderer>();

			if(renderer)
			{
				reverseKnockback = !renderer.flipX;
			}

			damager.HitCollider(p_collider.otherCollider, p_collider.otherCollider.GetComponent<Rigidbody2D>(), reverseKnockback);
		}
	}
}
