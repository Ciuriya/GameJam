using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "AI/Actions/Chase")]

public class ChaseAction : Action {

    public Transform chaseTarget;
    int MinDist = 5;
    int MaxDist = 10;
    int MoveSpeed = 4;

    public override void Execute(StateController controller)
    {
        Chase(controller);
    }

    private void Chase(StateController controller)
    {
        controller.transform.LookAt(chaseTarget);

        if(Vector2.Distance(controller.transform.position, chaseTarget.position) >= MinDist)
        {
            controller.transform.position += controller.transform.forward * MoveSpeed * Time.deltaTime;

            if (Vector2.Distance(controller.transform.position, chaseTarget.position) <= MaxDist)
            {

            }
        }
    }

}
