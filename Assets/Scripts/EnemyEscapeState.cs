using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyEscapeState : EnemyBaseState
{
    private float escapeTimer;
    private const float escapeDuration = 5.0f;
    public override void EnterState(EnemyStateManager enemy)
    {
        FluffEventsManager.Instance.Escape();
        Debug.Log("ESCAPE");

        Vector3 escapeDirection = enemy.transform.position - enemy.player.transform.position;
        Vector3 escapePoint = enemy.transform.position + escapeDirection.normalized * 15f;
        
        enemy.navMeshController.updateTargetPoint(escapePoint);

        escapeTimer = 0.0f;
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        escapeTimer += Time.deltaTime;
        if (escapeTimer >= escapeDuration)
        {
            enemy.switchState(enemy.lurkerState);
        }
    }
  

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider collision)
    {
        
    }

}
