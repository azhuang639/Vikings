using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public GameObject player;

    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //score++;
        //update to be based on how far player moves
        //calculate player x movement - origin
        //keep highest recorded x movement (compare player's current x position and high score, whichever is higher is displayed
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && player.transform.position.x >score)
        {
            score +=1;

        }
        scoreText.text = "Score: " + score;
    }
}
