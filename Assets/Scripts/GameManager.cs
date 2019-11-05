﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GUIManager MyGUIManager;
    private int score;
    public int health;
    private PlayerControll player;
    private float currTime;
    private float startTime;


   // Start is called before the first frame update
    private void Start()
    {
        startTime = Time.time;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControll>();
        health = player.health;
        score = 0;
        MyGUIManager.setScore(score.ToString());
        currTime = 0f;
    }
    public void EndGame(){
        Debug.Log("GAMEENDED");
        Time.timeScale = 0;
    }
    
    // Update is called once per frame
    private void Update()
    {
        float t = Time.time - startTime;
        string minutes = ((int)t / 60).ToString("00");
        string seconds;
       // if (t % 60 < 10) {
      //      seconds = 0 + (t % 60).ToString("f1");
      //  }
       // else
       // {
            seconds = (t % 60).ToString("00");
       // }

        currTime += 1 * Time.deltaTime;
        MyGUIManager.setTime(minutes + ":" + seconds );
    }
    public float getTime() { return currTime; }
    public void ScoreUp(int scorePlus){
        score+=scorePlus;
        MyGUIManager.setScore(score.ToString());
    }
    public void ScoreUp(){
        score++;
        MyGUIManager.setScore(score.ToString());
    }
}
