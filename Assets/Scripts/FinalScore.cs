using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class FinalScore : MonoBehaviour
{
    [SerializeField] private TMP_Text finalScoreText;
    public Scoring script;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (script.newHighScore == true)
        {
            finalScoreText.text = "New High Score: " + script.score;
        }
        else
        {
            finalScoreText.text = "Score: " + script.score;
        }
        
    }

}
