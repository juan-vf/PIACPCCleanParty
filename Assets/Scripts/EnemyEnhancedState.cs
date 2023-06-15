using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEnhancedState : EnemyBaseState
{
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("ENHANCED STATE");
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider collision)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemy)
    {

    }
    //public override void OnCollisionEnter(EnemyStateManager enemy)
    //{

    //}
}
