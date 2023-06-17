using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyLurkerState : EnemyBaseState
{
    
    //private int nextPoint;


    public override void EnterState(EnemyStateManager enemy)
    {
        // Debug.Log("Enter State from LurkerState");
        FluffEventsManager.Instance.Normal();

    }
    public override void UpdateState(EnemyStateManager enemy)
    {
   
    }
    public override void OnTriggerEnter(EnemyStateManager enemy, Collider collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("TENGO QUE PASAR A ESCAPE");

            enemy.switchState(enemy.escapeState);
            Debug.Log("NO PASED");
        }

    }
    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        if (collision.transform.CompareTag("PowerUp"))
        {
            
            Object.Destroy(collision.gameObject);
            enemy.switchState(enemy.enhancedState);
        }
    }

}
