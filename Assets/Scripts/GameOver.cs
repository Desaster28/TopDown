using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
        public bool gameOver = false;
        public void SetGameOver()
    {
        gameOver = true;
    }
    public void LoadMenu()
    {

        Time.timeScale = 1f;
       
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
