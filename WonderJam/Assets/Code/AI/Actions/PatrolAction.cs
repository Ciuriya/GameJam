using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[CreateAssetMenu(menuName = "AI/Actions/Patrol")]
public class PatrolAction : Action {

    public Transform[] wayPointsList;
    public int nextWayPoint;

    public override void Execute(StateController controller)
    {
        controller.navMeshAgent.autoBraking = false;
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        if (wayPointsList.Length == 0)
        {
            return;
        }
        controller.navMeshAgent.destination = wayPointsList[nextWayPoint].position;
        nextWayPoint = (nextWayPoint + 1) % wayPointsList.Length;
    }
}
