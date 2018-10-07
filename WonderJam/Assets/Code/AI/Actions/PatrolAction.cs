using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "AI/Actions/Patrol")]

public class PatrolAction : Action {

    public override void Execute(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        Vector3 direction = controller.points[controller.nextPoint].position - controller.transform.position;
        controller.transform.position += direction.normalized * controller.MoveSpeed * Time.deltaTime; 
        Debug.DrawRay(controller.transform.position, controller.points[controller.nextPoint].position - controller.transform.position,Color.green);

        if (Vector2.Distance(controller.transform.position, controller.points[controller.nextPoint].position) <= controller.distMin)
        {
            controller.nextPoint = (controller.nextPoint + 1) % controller.points.Length;
        }

    }

}
