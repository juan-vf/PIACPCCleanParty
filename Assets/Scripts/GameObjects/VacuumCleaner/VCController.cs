using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class VCController : MonoBehaviour
{
    private PlayerInputController PIController;
    private Rigidbody m_RB;
    [SerializeField]private float m_MoveForce = 100f;
    [SerializeField]private float m_StopForce = 50f;
    public float m_Battery = 100;
    private float m_BatteryTimeOfLive = 240f;
    private float m_BatteryTimeLive = 0;
    private float m_StorageBase = 100f;
    private float m_StorageActual = 100f;
    void Start()
    {
        PIController = GetComponent<PlayerInputController>();
        m_RB = GetComponent<Rigidbody>();

        //ESCUCHAS DE EVENTOS
        BatteryEventSystem.m_BES.OnSlowDown += SlowSpeed;
    }
    void Update()
    {
        m_BatteryTimeLive += Time.deltaTime;
        //DESCUENTA EL PORCENTAJE POR EL TIEMPO QUE PASA, DURA 240SEGUNDOS/4MINS
        m_Battery -= (Time.deltaTime * 100)/m_BatteryTimeOfLive;
        Debug.Log(m_Battery);
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move(){
        Debug.Log(PIController.IsMoving);

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
    private void SlowSpeed(){
        m_MoveForce = 50f;
        Debug.Log(m_MoveForce);
    }
    private void ChargeBattery(){
        //carga la bateria
    }
}
