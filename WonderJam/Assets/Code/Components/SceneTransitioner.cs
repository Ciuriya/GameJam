using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner : MonoBehaviour
{
	public string m_nextScene;

	public void SwitchScenes()
	{
		SceneManager.LoadScene(m_nextScene);
	}

}
