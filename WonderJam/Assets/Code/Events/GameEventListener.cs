using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
	[Tooltip("Event to register to.")]
	public GameEvent m_event;

	public UnityEvent m_response;

	protected virtual void OnEnable()
	{
		m_event.RegisterListener(this);
	}

	protected virtual void OnDisable()
	{
		m_event.UnregisterListener(this);
	}

	public void OnEventRaised()
	{
		m_response.Invoke();
	}
}
