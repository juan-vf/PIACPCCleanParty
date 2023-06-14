using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    EnemyEnhancedState EnhancedState = new EnemyEnhancedState();
    EnemyEscapeState EscapeState = new EnemyEscapeState();
    EnemyLurkerState LurkerState = new EnemyLurkerState();
    EnemyMessState MessState = new EnemyMessState();


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
