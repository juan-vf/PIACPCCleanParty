using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class VCController : MonoBehaviour
{
    private PlayerInputController PIController;
    private Rigidbody m_RB;
    [SerializeField]private float m_MoveForce = 100f;
    [SerializeField]private float m_StopForce = 50f;
    public float m_Battery = 100;
    private float m_BatteryTimeOfLive = 60f;
    private float m_BatteryTimeLive = 0;
    private float m_StorageBase = 100f;
    private float m_StorageActual = 100f;
    private bool crashed = false;

    //CREA LAS CLASES NECESARIAS
    private Storage m_storage = new Storage();
    void Start()
    {
        PIController = GetComponent<PlayerInputController>();
        m_RB = GetComponent<Rigidbody>();

        //ESCUCHAS DE EVENTOS
        BatteryEventSystem.m_BES.OnSlowDown += SlowSpeed;
        BatteryEventSystem.m_BES.OnDecomposed += ChashVC;
        BatteryEventSystem.m_BES.OnTakingDamage += DamageTheBattery;
        // UIEventsManager.UIEventSys.OnStorageUI += UpdateStorageUI;
        // Debug.Log(m_storage.getSPercentage);
    }
    void Update()
    {
        m_BatteryTimeLive += Time.deltaTime;
        //DESCUENTA EL PORCENTAJE POR EL TIEMPO QUE PASA, DURA 240SEGUNDOS/4MINS
        m_Battery -= (Time.deltaTime * 100)/m_BatteryTimeOfLive;
        // m_storage.FillStorage();
        UpdateStorageUI();

    }
    private void FixedUpdate()
    {
        if(!crashed){
            Move();
        }
    }
    private void Move(){
        if(PIController.IsMoving){
            m_RB.AddForce(new Vector3(PIController.getInputMove.x, 0f, PIController.getInputMove.y) * m_MoveForce);
        }
        Vector3 stopVector = -m_RB.velocity * m_StopForce;
        m_RB.AddForce(stopVector, ForceMode.Force);
    }
    public float getBattery{
        get{return m_Battery;}
        // set{m_BatteryTimeLive = value;}
    }
    public float getStorage{
        get{return m_storage.getSPercentage;}
        // set{m_BatteryTimeLive = value;}
    }
    public PlayerInputController getInputs{get{return PIController;}}
    private void SlowSpeed(){
        m_MoveForce *= 0.5f;
        // Debug.Log(m_MoveForce);
    }
    private void ChargeBattery(){
        //carga la bateria
    }
    private void UpdateStorageUI()
    {
        UIEventsManager.UIEventSys.StorageUI(m_storage.getSPercentage);
    }
    public bool getChashed{
        set{crashed = value;}
        // get{return crashed;}
    }
    public void ChashVC(){
        crashed = true;
    }
    private void DamageTheBattery(){
        m_Battery -= m_Battery * 0.3f;
    }

}
