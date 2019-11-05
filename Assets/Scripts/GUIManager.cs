using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public Text scoreTxt;
    public Text countTimer;
    public Text GameOverText;
    public Text highscoreTxt;

    // Start is called before the first frame update
    public void setScore(string score){
        scoreTxt.text = "Score: "+ score;
    }
    public void setDisplayScore(string score)
    {
        GameOverText.text = "Your Score: " + score;
    }
    public void setDisplayHighScore(string highscore)
    {
        highscoreTxt.text = "Highscore: " + highscore;
    }
    
    public void setTime(string time)
    {
        countTimer.text = time + "";
    }
    public void HealthM(){}
    public void HealthP(){}
}
