using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyEnhancedState : EnemyBaseState
{
    public float timer = 0f;

    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("ENHANCED STATE");
        FluffEventsManager.Instance.Enhanced();
        timer = 0f;
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider collision)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        timer += Time.deltaTime;
        if (timer >= 5f)
        {
            FluffEventsManager.Instance.Normal();
            enemy.switchState(enemy.lurkerState);

        }
    }
    //public override void OnCollisionEnter(EnemyStateManager enemy)
    //{

    //}
}
