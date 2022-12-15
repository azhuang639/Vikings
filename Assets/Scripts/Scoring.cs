using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Scoring : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    public GameObject player;

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
    }



    void Update()
    {
        if (player != null && Input.GetKeyDown(KeyCode.W) && player.transform.position.z >= score)
        {
            score +=1;

        }
        scoreText.text = "Score: " + score;
    }
}
