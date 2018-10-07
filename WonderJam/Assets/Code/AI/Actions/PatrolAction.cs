using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "AI/Actions/Patrol")]
public class PatrolAction : Action {

    public Transform[] points;
    public int nextPoint = 0;
    int MaxDist = 10;
    int MinDist = 1;
    int MoveSpeed = 4;


    public override void Execute(StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(StateController controller)
    {
        controller.transform.LookAt(points[nextPoint].position);
        if(Vector2.Distance (controller.transform.position, points[nextPoint].position) >= MinDist)
        {
            controller.transform.position += controller.transform.forward * MoveSpeed * Time.deltaTime;
            if (Vector2.Distance(controller.transform.position, points[nextPoint].position) <= MaxDist)
            {

            }
        }
        else
        {
            nextPoint = (nextPoint + 1) % points.Length;
        }
    }

}
