using UnityEngine;

[System.Serializable]
public class ChestDrop
{
    [Tooltip("The resource reference.")]
    public FloatVariable m_resource;

    [Tooltip("The resource max storage reference.")]
    public FloatVariable m_maxResourceStorage;

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
        if (Random.Range(0, 100) <= m_dropChance)
        {
            float dropAmount = Random.Range(m_minimumDropAmount, m_maximumDropAmount);

            float delta = m_maxResourceStorage.Value - m_resource.Value;

			if(delta == 0) return false;

			m_resource.Value += dropAmount;

            if (m_resource.Value > m_maxResourceStorage.Value)
            {
                m_resource.Value = m_maxResourceStorage.Value;
            }

            m_resourceEvent.Raise();

			return true;
        }

		return false;
    }
}
