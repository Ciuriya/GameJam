using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "AI/State")]
public class State : ScriptableObject
{
	public Action[] m_actions;
	public Transition[] m_transitions;
	public Color m_sceneGizmoColor = Color.grey;

	public void UpdateState(StateController p_controller)
	{
		ExecuteActions(p_controller);
		CheckTransitions(p_controller);
	}

	private void ExecuteActions(StateController p_controller)
	{
		for(int i = 0; i < m_actions.Length; ++i)
			m_actions[i].Execute(p_controller);
	}

	private void CheckTransitions(StateController p_controller)
	{
		for(int i = 0; i < m_transitions.Length; ++i)
			if(m_transitions[i].m_condition.Test(p_controller))
				p_controller.TransitionToState(m_transitions[i].m_trueState);
			else
				p_controller.TransitionToState(m_transitions[i].m_falseState);
	}
}
