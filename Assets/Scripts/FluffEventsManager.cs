using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FluffEventsManager : MonoBehaviour
{
    public static FluffEventsManager Instance;
    
    private void Awake()
    {
        Instance = this;  
    }
    public event Action OnEnhanced;
    public event Action OnNormal;
    public event Action OnEscape;
    public event Action OnDirtying;
    public void Enhanced()
    { 
        if (OnEnhanced != null) 
        { 
            OnEnhanced();
        }
    }

    public void Normal() { 
        if(OnNormal != null)
        { 
            OnNormal();
        }
    }
    public void Escape()
    {
    if(OnEscape != null)
        {
            OnEscape();
        }
    }

    public void Dirtying(){
        if(OnDirtying != null){
            OnDirtying();
        }
    }


}
