using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCSM : MonoBehaviour
{
    private VCBaseState m_ActualState;
    private VCBaseState m_InitialState;
    private VCBaseState DefaultState = new VCDefaultState();
    private VCBaseState LowBatteryS = new LowBatteryState();
    private VCController vCController;
    void Start()
    {
        vCController = GetComponent<VCController>();
        //ESCUCHAS DE EVENTOS
        //SE LE ASIGNA AL EVENTO, UNA FUNCION PARA QUE EJECUTE AL ESCUCHAR EL EVENTO 
        BatteryEventSystem.m_BES.OnBatteryLow += InitLowBatteryS;
        m_ActualState = DefaultState;
        m_ActualState.Enter(this);
    }
    void Update()
    {
        if (m_ActualState != null)
        {
            m_ActualState.Update(this);
        };
    }
    public void ActivateState(VCBaseState newState)
    {
        if (m_ActualState != null)
        {
            m_ActualState.Exit(this);
            return;
        }
        m_ActualState = newState;
        m_ActualState.Enter(this);
    }
    private void OnCollisionEnter(Collision other)
    {
        if(m_ActualState != null){
            m_ActualState.OnCollisionEnter(this, other);
        }
    }
    public void ChangeState(VCBaseState newState)
    {
        m_ActualState = newState;
        m_ActualState.Enter(this);
    }
    private void InitLowBatteryS(){
        ChangeState(LowBatteryS);
    }
    public VCController getVCC{
        get{return vCController;}
    }
}
