using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
   [SerializeField] public Transform[] WayPoints;

    EnemyBaseState currentState;
    public EnemyEnhancedState enhancedState = new EnemyEnhancedState();
    public EnemyEscapeState escapeState = new EnemyEscapeState();
    public EnemyLurkerState lurkerState = new EnemyLurkerState();
    //EnemyMessState messState = new EnemyMessState();
    
    [HideInInspector] public NavMeshController navMeshController;
    [HideInInspector] public GameObject player;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
        navMeshController = GetComponent<NavMeshController>();
        currentState = lurkerState;
        currentState.EnterState(this);
        FluffEventsManager.Instance.Dirtying();
        
    }

    void Update()
    {
        if (currentState != null) { 
        
            currentState.UpdateState(this);
        
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision); 
    }
    public void switchState(EnemyBaseState state) 
    {
        currentState = state;
        
        currentState.EnterState(this);
    }

}
