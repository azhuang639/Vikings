using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementLeft : MonoBehaviour
{
    [SerializeField] private float speed;

    //// Start is called before the first frame update
    //void Start()
    //{

    //}

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);


    }
    private void OnCollisionEnter(Collision collision)
    {
        //if we hit the ship
        if (collision.collider.GetComponent<Player>() != null)
        {
            Destroy(collision.gameObject);
        }
    }
}
