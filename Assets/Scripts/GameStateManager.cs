using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour
{
    public Scoring script;
    public GameObject bgmusic;
    public GameObject shipMusic;
    public GameObject gameOverMusic;
    public GameObject endMenu;
    public bool isOver;
    public GameObject pauseMenu;
    public bool isPaused;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        endMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void loadStartMenu()
    {
        SceneManager.LoadScene("StartMenu");

    }

    public void pauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        bgmusic.GetComponent<AudioSource>().Pause();
        shipMusic.GetComponent<AudioSource>().Pause();

    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        bgmusic.GetComponent<AudioSource>().Play();
        shipMusic.GetComponent<AudioSource>().Play();

    }
    public void endGame()
    {
        endMenu.SetActive(true);
        isOver = true;
        bgmusic.GetComponent<AudioSource>().Stop();
        shipMusic.GetComponent<AudioSource>().Stop();
        gameOverMusic.GetComponent<AudioSource>().Play();

    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }

    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restarted");
    }
}
