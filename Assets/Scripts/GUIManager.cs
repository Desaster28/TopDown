using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{

    public Text scoreTxt;
    public Text countTimer;
    public Image[] healthP;
    public Image[] healthM;
    public TextMesh txt;
    // Start is called before the first frame update
    public void setScore(string score){
        scoreTxt.text = "Score: "+ score;
    }
    public void setTime(string time)
    {
        countTimer.text = time + "";
    }
    public void HealthM(){}
    public void HealthP(){}
}
