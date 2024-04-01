using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : BaseState
{
    public int WaypointIndex;
    public override void Enter()
    {

    }
    public override void Perform()
    {
        PatrolCycle();
        if (enemy.MozeVidetiIgraca())
        {
            stateMasina.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {
        
    }
    public void PatrolCycle()
    {
        if(enemy.Agent.remainingDistance < 0.2f)
            {
                if (WaypointIndex < enemy.put.waypoints.Count -1)
                    WaypointIndex++;
                else 
                    WaypointIndex = 0;
                enemy.Agent.SetDestination(enemy.put.waypoints[WaypointIndex].position);
            }
    }
}
