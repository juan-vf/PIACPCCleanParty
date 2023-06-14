using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BatteryEventSystem : MonoBehaviour
{
    public static BatteryEventSystem m_BES;
    private void Awake()
    {
        m_BES = this;
    }
    //EVENTO PARA QUE EL CARGADOR EMPIECE A CARGAR(CAMBIE EL ESTADO A CARGADOR)
    public event Action OnChargerTriggerEnter;
    //EVENTO PARA QUE LA BATERIA CAMBIE A BATERIA BAJA
    public event Action OnBatteryLow;
    //EVENTO PARA QUE EL JUGADOR BAJE LA VELOCIDAD
    public event Action OnSlowDown;
    //EVENTO PARA QUE EL JUGADOR...

    public void ChargerTriggerEnter(){
        if(OnChargerTriggerEnter != null){
            OnChargerTriggerEnter();
        }
    }
    public void BatteryLow(){
        if(OnBatteryLow != null){
            OnBatteryLow();
        }
    }
    public void SlowDown(){
        if(OnSlowDown != null){
            OnSlowDown();
        }
    }
}
