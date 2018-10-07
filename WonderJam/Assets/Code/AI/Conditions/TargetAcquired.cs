using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Condition/TargetAcquired")]

public class TargetAcquired : Condition
{
    public override bool Test(StateController p_controller)
    {
        return true;
    }
}
