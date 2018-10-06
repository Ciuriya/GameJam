using UnityEngine;

public class Damager : MonoBehaviour
{
	[Tooltip("The damager's hurtbox.")]
	public GameObject m_hurtbox;

	[Tooltip("The SpriteRenderer used to get the flipX value needed to place the hurtbox.")]
	public SpriteRenderer m_spriteRenderer;

	public Vector2 m_offset = new Vector2(0.5f, 0f);

	public bool m_canDamage;

	public void EnableDamage()
	{
		m_canDamage = true;
	}

	public void DisableDamage()
	{
		m_canDamage = false;
	}

	public bool Damage()
	{
		if(!m_canDamage) return false;

		Vector3 hurtboxLoc = m_hurtbox.transform.position;

		m_hurtbox.transform.position = new Vector3(m_spriteRenderer.flipX ? -m_offset.x : m_offset.x, 
												   hurtboxLoc.y, 
												   hurtboxLoc.z);

		return true;
	}
}
