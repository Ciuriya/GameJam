using UnityEngine;

public class Enemy : MonoBehaviour
{
	[Tooltip("The loot table this enemy will use to find the drop it will drop.")]
	public EnemyDropRuntimeSet m_drops;

	[Tooltip("This enemy can die.")]
	public bool m_canDie;
	private bool m_isDead;

	public void DropRandom()
	{
		for(int i = 0; i < m_drops.Length(); ++i)
		{
			if(m_drops.m_items[i].Drop()) return;
		}
	}

	public void Kill()
	{
		if(m_canDie && !m_isDead)
		{
			if(m_drops) DropRandom();

			m_isDead = true;
			Die();
		}
	}

	protected virtual void Die()
	{
		Destroy(gameObject);
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy")&& collision.otherCollider.CompareTag("Enemy"))
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
    }
}
