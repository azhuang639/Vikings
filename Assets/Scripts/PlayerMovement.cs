using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed; 
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        float roundedx = Mathf.Round(position.x);
        float roundedy = Mathf.Round(position.y);
        float roundedz = Mathf.Round(position.z);

        if (Input.GetKeyDown(KeyCode.W)) {
            transform.position = (transform.position + new Vector3(1, 0, 0));
            transform.Rotate(Vector3.forward * speed * Time.deltaTime); 
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = (transform.position + new Vector3(-1, 0, 0));
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position = (transform.position + new Vector3(0, 0, 1));
            transform.Rotate(Vector3.right * speed * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position = (transform.position + new Vector3(0, 0, -1));
            transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
        }
    }
}
