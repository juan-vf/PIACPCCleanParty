using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingState : VCBaseState
{
    private float timer = 0f;
    public override void Enter(VCSM vCSM)
    {
        Debug.Log("ESTADO CARGANDOO");
        // BatteryEventSystem.m_BES.Working(false);
        vCSM.getVCC.IsWorking(false);
        timer = 0;
    }

    public override void Update(VCSM vCSM)
    {
        if(timer >= 2){
            timer = 0;
            vCSM.getVCC.ChargeBattery();
        }
        timer += Time.deltaTime;
        if(vCSM.getVCC.getBattery >= 100){
            vCSM.ChangeState(vCSM.getDefaultS);
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
        if(!collision.transform.CompareTag("Charger")){
            vCSM.ChangeState(vCSM.getDefaultS);
            Debug.Log("NO ESTOYYY");
        }
    }

    public override void OnCollisionStay(VCSM vCSM, Collision collision)
    {

        // if(timer >= 2f){
        //     // BatteryEventSystem.m_BES.ChargerTriggerEnter();
        //     vCSM.getVCC.ChargeBattery();
        //     Debug.Log("NO ESTOYYY");
        // }
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
