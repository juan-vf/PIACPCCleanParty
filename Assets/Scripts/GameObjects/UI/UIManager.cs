using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI Victory;
    public TextMeshProUGUI PScore;
    public TextMeshProUGUI EScore;
    // Start is called before the first frame update
    void Start()
    {

        Transform victoryObject = transform.Find("Victory");
        Transform PScoreObject = transform.Find("Enemy");
        Transform EScoreObject = transform.Find("Player");
        Victory = victoryObject.GetComponent<TextMeshProUGUI>();
        PScore = PScoreObject.GetComponent<TextMeshProUGUI>();
        EScore = EScoreObject.GetComponent<TextMeshProUGUI>();
        UIEventsManager.UIEventSys.OnStats += UpdateUi;

        // if (Victory != null)
        // {
        //     if()
        // }
        // if (PScore != null)
        // {
        //     PScore.text = PScore.ToString();
        // }
        // if (EScore != null)
        // {
        //     EScore.text = EScore.ToString();
        // }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateUi(int enemy, int player){
        PScore.text = enemy.ToString();
        EScore.text = player.ToString();
        Victory.text = (player > enemy) ? "Gano PELUSA" : "Gano la PELUSA";
    }
}
