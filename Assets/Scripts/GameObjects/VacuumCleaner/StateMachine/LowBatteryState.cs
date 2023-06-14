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
        BatteryEventSystem.m_BES.SlowDown();
    }
    public override void Update(VCSM vCSM)
    {
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