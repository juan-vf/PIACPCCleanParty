using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class VCBaseState
{
    public abstract void Enter(VCSM vCSM);
    public abstract void Update(VCSM vCSM);
    public abstract void Exit(VCSM vCSM);
    public abstract void OnCollisionEnter(VCSM vCSM, Collision collision);
    public abstract void OnCollisionStay(VCSM vCSM, Collision collision);
    public abstract void OnCollisionExit(VCSM vCSM, Collision collision);
    public abstract void OnTriggerEnter(VCSM vCSM, Collision collision);
    public abstract void OnTriggerStay(VCSM vCSM, Collision collision);
    public abstract void OnTriggerExit(VCSM vCSM, Collision collision);
}
