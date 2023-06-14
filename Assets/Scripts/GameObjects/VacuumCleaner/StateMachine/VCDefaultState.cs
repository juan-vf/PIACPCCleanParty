using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VCDefaultState : VCBaseState
{
    public override void Enter(VCSM vCSM)
    {
        // throw new System.NotImplementedException();
        Debug.Log("Default State");
    }
    public override void Update(VCSM vCSM)
    {
        if(vCSM.getVCC.getBattery <= 75){
            //SI EL PORCENTAJE DE LA BATERIA ES MENOR A 75%
            Debug.Log($"bateria BAJA");
            BatteryEventSystem.m_BES.BatteryLow();
        }
        // throw new System.NotImplementedException();
    }
    public override void Exit(VCSM vCSM)
    {
        throw new System.NotImplementedException();
    }
    public override void OnCollisionEnter(VCSM vCSM, Collision collision)
    {
        throw new System.NotImplementedException();
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
