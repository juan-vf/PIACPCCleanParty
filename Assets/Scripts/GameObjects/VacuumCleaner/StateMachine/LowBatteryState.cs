using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowBatteryState : VCBaseState
{
    public override void Enter(VCSM vCSM)
    {
        // throw new System.NotImplementedException();
        Debug.Log("Batery Low State");
        //PARA HACER
        /*
            Bajar la velocidad
        */
        BatteryEventSystem.m_BES.SlowDown();;
        UIEventsManager.UIEventSys.BatteryUI(1);
        // BatteryEventSystem.m_BES.Working(true);
        vCSM.getVCC.IsWorking(true);
    }
    public override void Update(VCSM vCSM)
    {
        if(vCSM.getVCC.getBattery <= 0){
            vCSM.ChangeState(vCSM.getDS);
        }
    }
    public override void Exit(VCSM vCSM)
    {
    }
    public override void OnCollisionEnter(VCSM vCSM, Collision collision)
    {
        if(collision.transform.CompareTag("Enemy")){
            BatteryEventSystem.m_BES.TakingDamage();
        }
    }
    public override void OnCollisionExit(VCSM vCSM, Collision collision)
    {
    }
    public override void OnCollisionStay(VCSM vCSM, Collision collision)
    {
        // throw new System.NotImplementedException();
    }
    public override void OnTriggerEnter(VCSM vCSM, Collision collision)
    {
        throw new System.NotImplementedException();
    }
    public override void OnTriggerExit(VCSM vCSM, Collision collision)
    {
        throw new System.NotImplementedException();
    }
    public override void OnTriggerStay(VCSM vCSM, Collision collision)
    {
        throw new System.NotImplementedException();
    }
}