using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;
    //[SerializeField] private Camera mainCamera;

    private Animator animator;
    private bool isHopping;

    //end game
    public EndGame EndGameScript;
    //private Rigidbody rigidbody;

    public GameObject shipWreck;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //rigidbody = GetComponent<Rigidbody>(); 
        //isHopping = false;
    }

    // Update is called once per frame
    void Update()
    {
      
    
        if (Input.GetKeyDown(KeyCode.W))// && !isHopping)
        {
            float xDifference = 0;
            if (transform.position.x % 1 != 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;
            }
            MovePlayer(new Vector3(xDifference, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.S))// && !isHopping)
        {
            float xDifference = 0;
            if (transform.position.x % 1 != 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;
            }
            MovePlayer(new Vector3(xDifference, 0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.A))// && !isHopping)
        {
            MovePlayer(new Vector3(-1, 0, 0));
     
        }
        else if (Input.GetKeyDown(KeyCode.D))// && !isHopping)
        {
            MovePlayer(new Vector3(1, 0, 0));
        }
    }

    public void FinishHop()
    {
        isHopping = false;
    }

    //private void RotatePlayer()
    //{
    //    float horizontalInput = Input.GetAxis("Horizontal");
    //    float verticalInput = Input.GetAxis("Vertical");

    //    Vector3 movement = new Vector3(horizontalInput, 0, verticalInput).normalized;

    //    if(movement == Vector3.zero)
    //    {
    //        return; 
    //    }

    //    Quaternion targetRotation = Quaternion.LookRotation(movement);

    //    Debug.Log(targetRotation.eulerAngles);

    //    targetRotation = Quaternion.RotateTowards(
    //        transform.rotation,
    //        targetRotation,
    //        360 * Time.fixedDeltaTime);

    //    rigidbody.MovePosition(rigidbody.position + movement * 30 * Time.fixedDeltaTime);
    //    rigidbody.MoveRotation(targetRotation);

    //}


    private void MovePlayer(Vector3 difference)
    {
        //mainCamera.transform.position = mainCamera.transform.position + difference;
        //animator.ResetTrigger("hop");
        animator.SetTrigger("hop");
        isHopping = true;
        transform.position = transform.position + difference;
        levelGenerator.SpawnTerrain(transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        shipWreck.GetComponent<AudioSource>().Play();
        levelGenerator.EndGame();
        Destroy(gameObject);
        Debug.Log("player lost");
        EndGameScript.endGame();
    }
}
