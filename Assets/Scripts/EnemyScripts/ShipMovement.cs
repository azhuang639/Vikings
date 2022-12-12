using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement: MonoBehaviour
{
    [SerializeField] private float speed;

    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        
    }

    //need to double check that the collider we are getting is the "wood" part of the ship
    //and that the ship is actually two units big
    private void OnCollisionEnter(Collision collision)
    {
        //if we hit the ship
        if(collision.collider.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject); 
        }
    }
}
