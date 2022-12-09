using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private LevelGenerator levelGenerator;

    private Animator animator;
    public bool isHopping;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        isHopping = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && !isHopping)
        {
            float xDifference = 0;
            if (transform.position.x % 1 != 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;
            }
            MovePlayer(new Vector3(xDifference, 0, 1));
        }
        else if (Input.GetKeyDown(KeyCode.S) && !isHopping)
        {
            float xDifference = 0;
            if (transform.position.x % 1 != 0)
            {
                xDifference = Mathf.Round(transform.position.x) - transform.position.x;
            }
            MovePlayer(new Vector3(xDifference, 0, -1));
        }
        else if (Input.GetKeyDown(KeyCode.A) && !isHopping)
        {
            MovePlayer(new Vector3(-1, 0, 0));
        }
        else if (Input.GetKeyDown(KeyCode.D) && !isHopping)
        {
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
}
