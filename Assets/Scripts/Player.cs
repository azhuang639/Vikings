using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private bool isHopping;

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
            animator.SetTrigger("hop");
            isHopping = true;
        }
    }

    public void FinishHop()
    {
        isHopping = false;
    }
}
