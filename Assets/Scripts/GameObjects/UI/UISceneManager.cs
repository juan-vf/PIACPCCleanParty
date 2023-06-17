using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneManager : MonoBehaviour
{
    private int ScoreP;
    private int ScoreE;
    private void Start()
    {

        if(UIEventsManager.UIEventSys != null){UIEventsManager.UIEventSys.OnLevelScore += LevelScoreChange;}
        if(PlayerPrefs.HasKey("PlayerScore") && PlayerPrefs.HasKey("EnemyScore")){
            ScoreP = PlayerPrefs.GetInt("PlayerScore");
            ScoreE = PlayerPrefs.GetInt("EnemyScore");
            if(UIEventsManager.UIEventSys != null){UIEventsManager.UIEventSys.Stats(ScoreE, ScoreP);}

        }
    }
    public void SceneLoader(int SceneIndex){
        SceneManager.LoadScene(SceneIndex);
    }
    public void LevelScoreChange(){
        SceneManager.LoadScene("LevelScore");
    }

}
