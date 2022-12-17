using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;

    private Animator animator;
    private bool isHopping;

    //end game
    public GameStateManager GameStateManagerScript;
    public GameObject shipWreck;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      
    
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.rotation = Quaternion.identity;
            float xDifference = 0;
            if (transform.position.x % 1 != 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;
            }
            MovePlayer(new Vector3(xDifference, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(0, 0, -1));
            float xDifference = 0;
            if (transform.position.x % 1 != 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;
            }
            MovePlayer(new Vector3(xDifference, 0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(-1, 0, 0));
            MovePlayer(new Vector3(-1, 0, 0));
     
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.LookRotation(new Vector3(1, 0, 0));
            MovePlayer(new Vector3(1, 0, 0));
        }
    }

    public void FinishHop()
    {
        isHopping = false;
    }


    private void MovePlayer(Vector3 difference)
    {
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = transform.position + difference;
        levelGenerator.SpawnTerrain(transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        shipWreck.GetComponent<AudioSource>().Play();
        //Debug.Log("Object that collided with me: " + other.gameObject.tag);
        levelGenerator.EndGame();
        Destroy(gameObject);
        //Debug.Log("player lost");
        GameStateManagerScript.endGame();
    }
}
