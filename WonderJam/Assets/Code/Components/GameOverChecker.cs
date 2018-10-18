using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverChecker : MonoBehaviour
{
	public BuildingLevelVariable m_shrineLevel;

	public void OnYearEnd()
	{
		if (!m_shrineLevel.Value.isLastLevel) SceneManager.LoadScene("Menu");
	}

	public void OnShrineUpgrade()
	{
		if(m_shrineLevel.Value.isLastLevel) SceneManager.LoadScene("Menu");
	}
}