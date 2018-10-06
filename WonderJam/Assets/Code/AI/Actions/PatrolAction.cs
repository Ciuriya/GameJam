using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(menuName = "AI/Actions/Patrol")]
public class PatrolAction : Action {



    public override void Execute(StateController controller)
    {
        controller.navMeshAgent.autoBraking = false;
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        if (controller.wayPointsList.Length == 0)
        {
            return;
        }
        controller.navMeshAgent.destination = controller.wayPointsList[controller.nextWayPoint].position;
        controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointsList.Length;
    }
}
