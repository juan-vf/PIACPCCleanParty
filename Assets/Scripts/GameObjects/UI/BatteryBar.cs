using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryBar : MonoBehaviour
{
    private Image BatteryImage;
    public Sprite SCrash;//id=4
    public Sprite SFull;//id=3
    public Sprite SHalf;//id=2
    public Sprite SEmpty;//id=1
    void Start()
    {
        BatteryImage = GetComponentInChildren<Image>();
        UIEventsManager.UIEventSys.OnBatteryUI += ChangeSprite;
    }
    void Update()
    {
    }
    public void ChangeSprite(int SpriteId){
        if(SpriteId == 1){
            BatteryImage.sprite = SEmpty;
        }else if(SpriteId == 2){
            BatteryImage.sprite = SHalf;
        }else if(SpriteId == 3){
            BatteryImage.sprite = SFull;
        }else if(SpriteId == 4){
            BatteryImage.sprite = SCrash;
        }
    }
}
