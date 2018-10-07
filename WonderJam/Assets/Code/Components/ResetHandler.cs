using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ResetHandler : MonoBehaviour
{
	public ResetRuntimeSet m_floatsToReset;
	public List<AbsRuntimeSet> m_setsToReset;

	void Awake()
	{
		for(int i = 0; i < m_floatsToReset.Length(); ++i)
		{
			ResettableVariable rv = m_floatsToReset.m_items[i];

			rv.m_variable.Value = rv.m_resetTo.Value;
		}

		for(int i = 0; i < m_setsToReset.Count; ++i)
		{
			AbsRuntimeSet ars = m_setsToReset[i];
			Type setType = ars.GetType();
			MethodInfo methodInfo = setType.GetMethod("ResetList");

			methodInfo.Invoke(ars, null);
		}
	}
}
