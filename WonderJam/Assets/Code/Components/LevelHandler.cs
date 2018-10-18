using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class LevelHandler : MonoBehaviour
{
	public LevelsRuntimeSet m_levels;
	public LevelsRuntimeSet m_levelsVisited;
	public BuildingLevelVariable m_currentLumberLevel;
	public BuildingLevelVariable m_currentFarmLevel;
	public BuildingLevelVariable m_currentQuarryLevel;
	public BuildingLevelVariable m_currentShrineLevel;
	public bool m_save;

	public void SaveBuildingLevels()
	{
		if(!m_save) return;

		PlayerPrefs.SetInt("Lumb", Int32.Parse(m_currentLumberLevel.Value.name.Substring(m_currentLumberLevel.Value.name.Length - 1)));
		PlayerPrefs.SetInt("Farm", Int32.Parse(m_currentFarmLevel.Value.name.Substring(m_currentFarmLevel.Value.name.Length - 1)));
		PlayerPrefs.SetInt("Quar", Int32.Parse(m_currentQuarryLevel.Value.name.Substring(m_currentQuarryLevel.Value.name.Length - 1)));
		PlayerPrefs.SetInt("Shri", Int32.Parse(m_currentShrineLevel.Value.name.Substring(m_currentShrineLevel.Value.name.Length - 1)));
	}

	public void LoadRandomLevel()
	{
		string level = null;

		while(level == null && m_levels.Length() >= m_levelsVisited.Length())
		{
			string temp = m_levels.m_items[UnityEngine.Random.Range(0, m_levels.Length())];

			if(!m_levelsVisited.Contains(temp))
			{
				level = temp;
			}
		}

		m_levelsVisited.m_items.Add(level);

		SceneManager.LoadScene(level);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
			SaveBuildingLevels();
            LoadRandomLevel();
        }
    }
}
