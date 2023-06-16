using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VCSM : MonoBehaviour
{
    private VCBaseState m_ActualState;
    private VCBaseState m_InitialState;
    private VCBaseState DefaultState = new VCDefaultState();
    private VCBaseState LowBatteryS = new LowBatteryState();
    private VCBaseState DecomposedState = new DecomposedState();
    private VCBaseState ChargingState = new ChargingState();
    private VCController vCController;
    private VCFuzzyManager vCFuzzyManager;
    void Start()
    {
        vCController = GetComponent<VCController>();
        vCFuzzyManager = GetComponent<VCFuzzyManager>();
        //ESCUCHAS DE EVENTOS
        //SE LE ASIGNA AL EVENTO, UNA FUNCION PARA QUE EJECUTE AL ESCUCHAR EL EVENTO 
        BatteryEventSystem.m_BES.OnBatteryLow += InitLowBatteryS;
        BatteryEventSystem.m_BES.OnDecomposed += InitDecomposedS;
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
    private void OnCollisionStay(Collision other)
    {
        if(m_ActualState != null){
            m_ActualState.OnCollisionStay(this, other);
        }
    }
private void OnCollisionExit(Collision other)
    {
        if(m_ActualState != null){
            m_ActualState.OnCollisionExit(this, other);
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
    private void InitDecomposedS(){
        /*FALTA EL ESTADO DESCOMPUESTOOOO*/
        ChangeState(getDS);
    }
    public VCController getVCC{
        get{return vCController;}
    }
    public VCFuzzyManager getFuzzyM{
        get{return vCFuzzyManager;}
    }
    public VCBaseState getLBS{
        get{return LowBatteryS;}
    }
    public VCBaseState getDS{
        get{return DecomposedState;}
    }
    public VCBaseState getChargingS{
        get{return ChargingState;}
    }
    public VCBaseState getDefaultS{
        get {return DefaultState;}
    }
}
