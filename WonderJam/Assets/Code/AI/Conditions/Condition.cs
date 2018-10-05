using UnityEngine;

public abstract class Condition : ScriptableObject
{
	public abstract bool Test(StateController p_controller);
}
