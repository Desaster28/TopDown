using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool esc = false;
    public GameObject PauseMenuUI;
    public bool GameOver;
    private void Start()
    {
        GameOver = false;
    }
    // Update is called once per frame
    public void SetGameOver()
    {
        GameOver = true;
    }
    void Update()
    {
        if (GameOver == true)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (esc)
            {
                Resume();
            }
            else { Pause(); }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        esc = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        esc = true;
    }
    public void LoadMenu()
    {

        Time.timeScale = 1f;
        esc = false;
        SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
        Debug.Log("QuitGame");
        Application.Quit();
    }
}
