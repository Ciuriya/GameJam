using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
	public State m_currentState;
	public bool m_drawGizmos;

	[HideInInspector] public float m_stateTimeElapsed;

	private void Update()
	{
		m_currentState.UpdateState(this);
	}

	public void TransitionToState(State p_nextState)
	{
		if(p_nextState != m_currentState)
		{
			m_currentState = p_nextState;
			OnExitState();
		}
	}

	public bool CheckCountdown(float p_duration)
	{
		m_stateTimeElapsed += Time.deltaTime;

		return m_stateTimeElapsed >= p_duration;
	}

	private void OnExitState()
	{
		m_stateTimeElapsed = 0;
	}
}
