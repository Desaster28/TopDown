using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUIManager MyGUIManager;
    private int score;
    public int health;
    private PlayerControll player;


   // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        health = player.health;
        score = 0;
        MyGUIManager.setScore(score.ToString());    
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
    public void ScoreUp(int scorePlus){
        score+=scorePlus;
        MyGUIManager.setScore(score.ToString());
    }
    public void ScoreUp(){
        score++;
        MyGUIManager.setScore(score.ToString());
    }
}
