using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ship;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeparationTime;
    [SerializeField] private float maxSeparationTime;

    private List<GameObject> currentShips = new List<GameObject>();

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
            currentShips.Add(Instantiate(ship, spawnPos.position, Quaternion.identity));
        }
     
    }

    private void OnDestroy()
    {
        foreach (GameObject currentShip in currentShips)
        {
            Destroy(currentShip);
        }
    }
}

