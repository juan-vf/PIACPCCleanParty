using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIEventsManager : MonoBehaviour
{
    public static UIEventsManager UIEventSys;
    private void Awake()
    {
        UIEventSys = this;
    }
    
    public event Action<float> OnStorageUI;

    public event Action<int> OnBatteryUI;

    public void StorageUI(float value){
        if(OnStorageUI != null){
            OnStorageUI(value);;
        }
    }
    public void BatteryUI(int spriteId){
        if(OnBatteryUI != null){
            OnBatteryUI(spriteId);
        }
    }
}
