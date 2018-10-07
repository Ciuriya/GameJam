using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Feedback
{
	public FloatVariable m_globalValue;
	public Sprite m_spriteValue;
	private float m_localValue = 0;

	public float UpdateLocalValue()
	{
		float diff = m_globalValue.Value - m_localValue;

		m_localValue = m_globalValue.Value;

		return diff;
	}
}
