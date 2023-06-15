using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private float m_StoragePercentage = 0f;
    private float m_StoragePixelsForClean = 200f;
    public Storage(){}

    public float getSPercentage{
        get{return m_StoragePercentage;}
        set{m_StoragePercentage = value;}
    }
    public float getStoragePixelsForClean{
        get{return m_StoragePixelsForClean;}
        set{m_StoragePixelsForClean = value;}
    }
    public void FillStorage(){
        if(m_StoragePercentage == 100f){return;}
        m_StoragePercentage += Time.deltaTime * 0.1f;
    }
    public void EmptyStorage(){
        m_StoragePercentage -= Time.deltaTime * 0.2f;
    }

}
