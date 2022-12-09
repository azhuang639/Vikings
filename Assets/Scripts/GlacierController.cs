using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlacierController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject glacier;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        glacier.transform.position = glacier.transform.position + new Vector3(0, 0, speed * Time.deltaTime);
    }
}
