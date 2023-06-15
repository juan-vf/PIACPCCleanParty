using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VCDefaultState : VCBaseState
{
    public override void Enter(VCSM vCSM)
    {
        Debug.Log("Default State");
        UIEventsManager.UIEventSys.BatteryUI(3);
        
    }
    public override void Update(VCSM vCSM)
    {
        if(vCSM.getFuzzyM.LowBattery){
            vCSM.ChangeState(vCSM.getLBS);
        }else if(vCSM.getFuzzyM.DecomposedState){
            vCSM.ChangeState(vCSM.getDS);
        }else if(vCSM.getFuzzyM.HalfBattery){
            UIEventsManager.UIEventSys.BatteryUI(2);
        }

        if(vCSM.getVCC.getInputs.IsCleaningKeyPressed){
            BatteryEventSystem.m_BES.Cleaning();
        }
    }
    public override void Exit(VCSM vCSM)
    {
        throw new System.NotImplementedException();
    }
    public override void OnCollisionEnter(VCSM vCSM, Collision collision)
    {
        if(collision.transform.CompareTag("Enemy")){
            BatteryEventSystem.m_BES.TakingDamage();
        }
    }
    public override void OnCollisionExit(VCSM vCSM, Collision collision)
    {
        throw new System.NotImplementedException();
    }
    public override void OnCollisionStay(VCSM vCSM, Collision collision)
    {
        throw new System.NotImplementedException();
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
