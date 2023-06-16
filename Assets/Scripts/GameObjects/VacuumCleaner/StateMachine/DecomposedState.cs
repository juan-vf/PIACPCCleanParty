using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecomposedState : VCBaseState
{
    private float timer = 0f;
    public override void Enter(VCSM vCSM)
    {
        Debug.Log("ESTADO DESCOMPUESTO");
        UIEventsManager.UIEventSys.BatteryUI(4);
        // BatteryEventSystem.m_BES.Decomposed();
        BatteryEventSystem.m_BES.Working(false);

        vCSM.getVCC.getChashed = true;

    }

    public override void Update(VCSM vCSM)
    {
        timer += Time.deltaTime;
        // Debug.Log(timer);
        if(timer >= 2f){
            Debug.Log("Cambiaraaaa");
            UIEventsManager.UIEventSys.LevelScore();
        }
    }
    public override void Exit(VCSM vCSM)
    {
    }

    public override void OnCollisionEnter(VCSM vCSM, Collision collision)
    {
    }

    public override void OnCollisionExit(VCSM vCSM, Collision collision)
    {
    }

    public override void OnCollisionStay(VCSM vCSM, Collision collision)
    {
    }

    public override void OnTriggerEnter(VCSM vCSM, Collision collision)
    {
    }

    public override void OnTriggerExit(VCSM vCSM, Collision collision)
    {
    }

    public override void OnTriggerStay(VCSM vCSM, Collision collision)
    {
    }
}
