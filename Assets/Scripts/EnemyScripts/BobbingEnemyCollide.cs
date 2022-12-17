using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingEnemyCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision collision)
    {
        //if we hit the ship
        if (collision.collider.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
