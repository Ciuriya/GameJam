using UnityEngine;

[System.Serializable]
public class EnemyDrop
{
	[Tooltip("The resource to drop.")]
	public FloatVariable m_resource;

	[Tooltip("The maximum amount of the resource you can obtain.")]
	public FloatVariable m_resourceMax;

	[Tooltip("The resource event needed to update the resource value in-game.")]
	public GameEvent m_resourceEvent;

	[Tooltip("The chance of getting this drop.")]
	public float m_dropChance;

	[Tooltip("The minimum amount of that resource that can drop.")]
	public int m_minimumDropAmount;

	[Tooltip("The maximum amount of that resource that can drop.")]
	public int m_maximumDropAmount;

	public bool Drop()
	{
		if(Random.Range(0, 100) <= m_dropChance)
		{
			float resourceValue = m_resource.Value + Random.Range(m_minimumDropAmount, m_maximumDropAmount);

			if(resourceValue > m_resourceMax.Value) resourceValue = m_resourceMax.Value;

			m_resource.Value = resourceValue;
			m_resourceEvent.Raise();

			return true;
		}

		return false;
	}
}
