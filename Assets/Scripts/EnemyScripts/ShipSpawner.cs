using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ship;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeparationTime;
    [SerializeField] private float maxSeparationTime;

    private void Start()
    {
        StartCoroutine(SpawnShip()); 
        
    }

    private IEnumerator SpawnShip()
    {
        //ships spawn indefinitely 
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
            Instantiate(ship, spawnPos.position, Quaternion.identity);
        }
     
    }
}

