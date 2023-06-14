using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChargerBaseState : MonoBehaviour
{
    public abstract void Enter(CSM cSM);
    public abstract void Update(CSM cSM);
    public abstract void Exit(CSM cSM);
    public abstract void OnCollisionEnter(CSM cSM, Collision collision);
    public abstract void OnCollisionStay(CSM cSM, Collision collision);
    public abstract void OnCollisionExit(CSM cSM, Collision collision);
    public abstract void OnTriggerEnter(CSM cSM, Collision collision);
    public abstract void OnTriggerStay(CSM cSM, Collision collision);
    public abstract void OnTriggerExit(CSM cSM, Collision collision);

}
