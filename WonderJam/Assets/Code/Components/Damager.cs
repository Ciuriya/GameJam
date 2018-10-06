using UnityEngine;
using UnityEngine.Events;

public class Damager : MonoBehaviour
{
	[Tooltip("The damager's hurtbox.")]
	public GameObject m_hurtbox;

	[Tooltip("The SpriteRenderer used to get the flipX value needed to place the hurtbox.")]
	public SpriteRenderer m_spriteRenderer;

	[Tooltip("Hurtbox offset.")]
	public Vector2 m_offset = new Vector2(0.5f, 0f);
	private Vector2 m_currentOffset = new Vector2(0f, 0f);

	[Tooltip("Damage inflicted by a hit of the damager.")]
	public FloatReference m_damage;
	public bool m_canDamage;

	[Tooltip("Knockback amount.")]
	public FloatReference m_knockbackValue;

	[Tooltip("Time between hits.")]
	public FloatReference m_damageCooldown;
	private float m_lastHit;

	[Tooltip("Layers this damager can hit.")]
	public LayerMask m_hittableLayers;
	public UnityEvent m_damageEvent;

	private Collider2D[] m_attackOverlapResults = new Collider2D[10];
	private ContactFilter2D m_attackContactFilter;

	void Awake()
	{
		m_attackContactFilter.layerMask = m_hittableLayers;
		m_attackContactFilter.useLayerMask = true;
	}

	public void EnableDamage()
	{
		m_canDamage = true;
	}

	public void DisableDamage()
	{
		m_canDamage = false;
	}

	private float GetMillisSinceLastHit()
	{
		float time = Time.time * 1000;

		return time - m_lastHit;
	}

	private bool IsOnCooldown()
	{
		float time = Time.time * 1000;

		return time < m_lastHit + m_damageCooldown.Value * 1000;
	}

	public bool Damage()
	{
		if(!m_canDamage || IsOnCooldown()) return false;

		m_lastHit = Time.time * 1000;

		m_hurtbox.SetActive(true);

		float offsetVal = m_spriteRenderer.flipX ? -m_offset.x : m_offset.x;
		Vector3 hurtboxLoc = m_hurtbox.transform.position;

		m_hurtbox.transform.Translate(new Vector3(offsetVal, 0));

		m_currentOffset = new Vector2(offsetVal, m_currentOffset.y);

		Bounds hurtboxBounds = m_hurtbox.GetComponent<Collider2D>().bounds;
		int hitCount = Physics2D.OverlapArea(hurtboxBounds.min, hurtboxBounds.max, m_attackContactFilter, m_attackOverlapResults);

		ResetHurtbox();

		for(int i = 0; i < hitCount; ++i)
		{
			Collider2D hit = m_attackOverlapResults[i];

			if(hit.gameObject != gameObject)
				HitCollider(hit, hit.GetComponent<Rigidbody2D>(), false);
		}

		return true;
	}

	public void HitCollider(Collider2D p_hit, Rigidbody2D p_rigid, bool p_reverseKnockback)
	{
		UnitHealth health = p_hit.GetComponent<UnitHealth>();

		if (health)
		{
			m_damageEvent.Invoke();
			health.Damage(m_damage.Value);

			if (p_rigid)
			{
				float force = m_knockbackValue.Value * 2;
				Vector2 velocity = new Vector2(force * (m_spriteRenderer.flipX ? -1 : 1), force);

				velocity.x *= (p_reverseKnockback ? -1 : 1);

				if(p_hit.CompareTag("Player"))
					p_hit.GetComponent<PlayerController>().Knockback(new Vector2(velocity.x, velocity.y));
				else p_rigid.velocity = velocity;
			}
		}
	}

	public void ResetHurtbox()
	{
		m_hurtbox.transform.Translate(new Vector3(-m_currentOffset.x, 0));
		m_hurtbox.SetActive(false);
	}
}
