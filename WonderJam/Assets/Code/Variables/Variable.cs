using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variable<T> : ScriptableObject
{
#if UNITY_EDITOR
    [Multiline, SerializeField]
    private string m_developerDescription;
#endif

    [SerializeField]
    private T m_value;

    public T Value
    {
        get { return m_value; }
        set { m_value = value; }
    }
}
