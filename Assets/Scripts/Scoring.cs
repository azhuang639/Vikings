using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text highScoreText;
    public GameObject player;

    public bool newHighScore = false;

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }



    void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.W) && player.transform.position.z >= score)
        {
            score +=1;

        }
        scoreText.text = "Score: " + score;
        CheckHighScore();
    }

    void CheckHighScore()
    {
        if (score > PlayerPrefs.GetInt("highScore", 0))
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = "High Score: " + score;
            newHighScore = true;
        }
    }
}
