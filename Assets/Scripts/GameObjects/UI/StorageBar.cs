using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StorageBar : MonoBehaviour
{
    private Slider m_StorageSlider;
    // Start is called before the first frame update
    void Start()
    {
        
        m_StorageSlider = GetComponent<Slider>();

        UIEventsManager.UIEventSys.OnStorageUI += UpdateStorageUI;

    }
    private void UpdateStorageUI(float value){
        m_StorageSlider.value = value;
        // Debug.Log(value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
