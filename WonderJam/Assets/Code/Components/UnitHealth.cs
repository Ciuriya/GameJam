using UnityEngine;
using UnityEngine.Events;

public class UnitHealth : MonoBehaviour
{
	[Tooltip("Unit's health")]
	public float m_health;

	[Tooltip("Unit's max health")]
	public float m_maxHealth;

	[Tooltip("Event called when the entity dies.")
	public UnityEvent m_deathEvent;

	public void Damage(float p_amount)
	{
		m_health -= p_amount;

		if(m_health <= 0.0f)
			m_deathEvent.Invoke();
	}
}
