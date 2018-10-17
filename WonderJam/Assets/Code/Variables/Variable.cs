using UnityEngine;

public class Variable<T> : ScriptableObject
{
    [Multiline, SerializeField]
    private string m_developerDescription;

    [SerializeField]
    private T m_value;

    public T Value
    {
        get { return m_value; }
        set { m_value = value; ForceSerialization(); }
    }

	void ForceSerialization()
	{
	#if UNITY_EDITOR
		UnityEditor.EditorUtility.SetDirty(this);
	#endif
	}
}
