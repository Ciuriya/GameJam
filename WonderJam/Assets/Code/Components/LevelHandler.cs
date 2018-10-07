using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour
{
	public LevelsRuntimeSet m_levels;
	public LevelsRuntimeSet m_levelsVisited;

	public void LoadRandomLevel()
	{
		string level = null;

		while(level == null && m_levels.Length() >= m_levelsVisited.Length())
		{
			string temp = m_levels.m_items[Random.Range(0, m_levels.Length() - 1)];

			if(!m_levelsVisited.Contains(temp))
			{
				level = temp;
			}
		}

		m_levelsVisited.Add(level);

		SceneManager.LoadScene(level);
	}

	public void RestartLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
