﻿using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ResetHandler : MonoBehaviour
{
	public SeasonVariable m_currentSeason;
	public Season m_startingSeason;
	public GameEventRuntimeSet m_eventsToRaise;
	public ResetFloatRuntimeSet m_floatsToReset;
	public ResetBuildingLevelRuntimeSet m_buildingsToReset;
	public ResetBuildingLevelRuntimeSet m_buildingsToLoad;
	public bool m_resetPrefs;
	public List<AbsRuntimeSet> m_setsToReset;

	void Start()
	{
		Time.timeScale = 1f;

		if(m_currentSeason != null && m_startingSeason != null) m_currentSeason.Value = m_startingSeason;

		if(m_buildingsToReset)
		{
			for(int i = 0; i < m_buildingsToReset.Length(); ++i)
			{
				ResettableBuildingLevel rbl = m_buildingsToReset.m_items[i];

				rbl.m_variable.Value = rbl.m_resetTo;
			}
		}

		if (m_floatsToReset)
		{
			for (int i = 0; i < m_floatsToReset.Length(); ++i)
			{
				ResettableFloat rf = m_floatsToReset.m_items[i];

				rf.m_variable.Value = rf.m_resetTo.Value;
			}
		}

		if (m_setsToReset.Count > 0)
		{
			for (int i = 0; i < m_setsToReset.Count; ++i)
			{
				AbsRuntimeSet ars = m_setsToReset[i];
				Type setType = ars.GetType();
				MethodInfo methodInfo = setType.GetMethod("ResetList");

				methodInfo.Invoke(ars, null);
			}
		}

		LoadLevels();

		if (m_eventsToRaise)
		{
			for (int i = 0; i < m_eventsToRaise.Length(); ++i)
			{
				GameEvent gameEvent = m_eventsToRaise.m_items[i];

				gameEvent.Raise();
			}
		}
	}

	void LoadLevels()
	{
		if(m_resetPrefs)
		{
			PlayerPrefs.DeleteAll();
		}

		if(!m_buildingsToLoad) return;

		for (int i = 0; i < m_buildingsToLoad.Length(); ++i)
		{
			int level = PlayerPrefs.GetInt(m_buildingsToLoad.m_items[i].m_variable.name.Substring(0, 4), 0);
			BuildingLevel current = m_buildingsToLoad.m_items[i].m_resetTo;

			for(int j = 0; j < level; ++j)
			{
				current = current.nextLevel;
			}

			m_buildingsToLoad.m_items[i].m_variable.Value = current;
		}
	}
}