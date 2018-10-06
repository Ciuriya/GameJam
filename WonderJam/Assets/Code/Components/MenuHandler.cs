using UnityEngine;

public class MenuHandler : MonoBehaviour
{
	// The currently opened menu. If null, the game is not currently paused.
	private GameObject m_currentMenu;

	// The previously opened menu.
	private GameObject m_previousMenu;

	[Tooltip("The game event raised when the game is paused.")]
	public GameEvent m_pauseEvent;

	[Tooltip("The game event raised when the game is resumed.")]
	public GameEvent m_resumeEvent;

	private void Update()
	{
		bool isPaused = m_currentMenu;

		if(Input.GetButtonDown("Cancel") && !isPaused)
			m_pauseEvent.Raise();
		else if(Input.GetButtonDown("Cancel") && isPaused)
			m_resumeEvent.Raise();
	}

	public void ChangeMenu(GameObject p_menu)
	{
		m_previousMenu = m_currentMenu;
		m_currentMenu = p_menu;
	}

	public void ClearMenu()
	{
		m_currentMenu = null;
	}

	public void Pause()
	{
		Time.timeScale = 0f;
	}

	public void Resume()
	{
		Time.timeScale = 1f;
	}
}
