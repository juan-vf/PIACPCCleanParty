using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Storage : MonoBehaviour
{
    private float m_StoragePercentage = 0f;
    private int m_StoragePixelsForClean = 10000;
    public Storage(){}

    public float getSPercentage{
        get{return m_StoragePercentage;}
        set{m_StoragePercentage = value;}
    }
    public int getStoragePixelsForClean{
        get{return m_StoragePixelsForClean;}
        set{m_StoragePixelsForClean = value;}
    }
    public void FillStorage(int painted){
        if(painted >= m_StoragePixelsForClean){return;}
        Debug.Log(painted);
        m_StoragePercentage = (painted * 100)/ m_StoragePixelsForClean;
    }
    public bool IsFull{get{return m_StoragePercentage == 100;}}
    public void EmptyStorage(){
        m_StoragePercentage -= Time.deltaTime * 0.2f;
    }

}
