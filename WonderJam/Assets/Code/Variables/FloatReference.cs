[System.Serializable]
public class FloatReference
{
	public bool m_useConstant = true;
	public float m_constantValue;
	public FloatVariable m_variable;

	public FloatReference() { }

	public FloatReference(float p_value)
	{
		m_useConstant = true;
		m_constantValue = p_value;
	}

	public float Value
	{
		get
		{
			return m_useConstant ? m_constantValue : m_variable.Value;
		}
	}
}
