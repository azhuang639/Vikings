using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public Scoring script;

    public GameObject endMenu;
    public bool isOver;
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
