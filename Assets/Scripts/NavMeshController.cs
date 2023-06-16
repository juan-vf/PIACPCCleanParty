using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private int nextPoint;
    private EnemyStateManager enemyStateManager;
    private float normalSPeed;

    void Start()
    {

        enemyStateManager = GetComponent<EnemyStateManager>(); 
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = 8f;
        normalSPeed = navMeshAgent.speed;
        updateTargetPoint(enemyStateManager.WayPoints[0].position);
        FluffEventsManager.Instance.OnEnhanced += SpeedChanges;
        FluffEventsManager.Instance.OnNormal += NormalSpeed;
        FluffEventsManager.Instance.OnEscape += SpeedChanges;
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
        //Debug.Log(navMeshAgent.destination);
    }

    public void StopNavMeshAgent()
    { 
        navMeshAgent.isStopped=true;
    }

    public bool weHaveArrived()
    {
       
    
        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending; 
    }

    private void SpeedChanges()
    {
        navMeshAgent.speed = normalSPeed*1.5f;
    }
    private void NormalSpeed()
    {
        navMeshAgent.speed = normalSPeed;
    }
 
}
