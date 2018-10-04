using UnityEngine;

[CreateAssetMenu]
public class FloatVariable : ScriptableObject
{

#if UNITY_EDITOR
	[Multiline, SerializeField]
	private string m_developerDescription;
#endif

	[SerializeField]
	private float m_value;

	public float Value
	{
		get { return m_value; }
		set { m_value = value; }
	}
}
