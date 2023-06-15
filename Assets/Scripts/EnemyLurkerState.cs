using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLurkerState : EnemyBaseState
{
    
    //private int nextPoint;


    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("Enter State from LurkerState");
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        //if (enemy.navMeshController.weHaveArrived())
        //{
        //    nextPoint = (nextPoint + 1) % enemy.WayPoints.Length;
        //    updateWayPoint(enemy);
        //}
    }
    public override void OnTriggerEnter(EnemyStateManager enemy, Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            enemy.switchState(enemy.escapeState);
        }

    }


    //void updateWayPoint(EnemyStateManager enemy)
    //{
    //    enemy.navMeshController.updateTargetPoint(enemy.WayPoints[nextPoint].position);
    //}

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        if (collision.transform.CompareTag("PowerUp"))
        {
            enemy.switchState(enemy.enhancedState);
        }
    }
}
