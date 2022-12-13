using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Scoring script;

    public GameObject endMenu;
    public bool isOver;
    public GameObject bgmusic;
    public GameObject shipMusic;
    // Start is called before the first frame update
    void Start()
    {
        endMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void endGame()
    {
        endMenu.SetActive(true);
        isOver = true;
        bgmusic.GetComponent<AudioSource>().Stop();
        shipMusic.GetComponent<AudioSource>().Stop();

    }

    public void resetLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("restarted");
    }
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quit game");
    }
}
