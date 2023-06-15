using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private int nextPoint;
    private EnemyStateManager enemyStateManager;

    void Start()
    {
        enemyStateManager = GetComponent<EnemyStateManager>(); 
        navMeshAgent = GetComponent<NavMeshAgent>();
        updateTargetPoint(enemyStateManager.WayPoints[0].position);
    }
        
    // Update is called once per frame
    void Update()
    {

        if (weHaveArrived())
        {
            nextPoint = (nextPoint + 1) % enemyStateManager.WayPoints.Length;
            updateTargetPoint(enemyStateManager.WayPoints[nextPoint].position);
        }
    }

    public void updateTargetPoint(Vector3 targetPoint) 
    {
        navMeshAgent.destination = targetPoint;
        navMeshAgent.isStopped = false;
        Debug.Log(navMeshAgent.destination);
    }

    public void StopNavMeshAgent()
    { 
        navMeshAgent.isStopped=true;
    }

    public bool weHaveArrived()
    {
       
    
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending; 
    }
}
