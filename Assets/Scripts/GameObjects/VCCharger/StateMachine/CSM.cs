using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSM : MonoBehaviour
{
    private ChargerBaseState m_ActualState;
    private ChargerBaseState m_InitialState;
    private ChargerBaseState chargingState = new ChargingState();
    private ChargerBaseState  offState = new OffState();
    void Start()
    {
        m_InitialState = offState;
        m_ActualState = m_InitialState;
        m_ActualState.Enter(this);
    }
    void Update()
    {
        if (m_ActualState != null)
        {
            m_ActualState.Update(this);
        };
    }
    public void ActivateState(ChargerBaseState newState)
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
    public void ChangeState(ChargerBaseState newState)
    {
        m_ActualState = newState;
        m_ActualState.Enter(this);
    }
}
