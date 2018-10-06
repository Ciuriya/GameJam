using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(menuName = "AI/Actions/Patrol")]
public class PatrolAction : Action {



    public override void Execute(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
       
    }

}
