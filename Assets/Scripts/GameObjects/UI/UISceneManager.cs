using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UISceneManager : MonoBehaviour
{
    private void Start()
    {
        UIEventsManager.UIEventSys.OnLevelScore += LevelScoreChange;
        if(PlayerPrefs.HasKey("PlayerScore")){
            Debug.Log(PlayerPrefs.GetInt("PlayerScore"));
        }
    }
    public void SceneLoader(int SceneIndex){
        SceneManager.LoadScene(SceneIndex);
    }
    public void LevelScoreChange(){
        SceneManager.LoadScene("LevelScore");
    }

}
