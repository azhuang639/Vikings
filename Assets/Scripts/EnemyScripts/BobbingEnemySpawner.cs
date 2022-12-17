using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobbingEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject bobbingEnemy;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeparationTime=2;
    [SerializeField] private float maxSeparationTime = 5;
    [SerializeField] private float minXPosition = -40;
    [SerializeField] private float maxXPosition = 40;
    [SerializeField] private int numBobbingEnemies = 10;

    private List<GameObject> currentBobbingEnemies;

    // Start is called before the first frame update
    void Start()
    {
        currentBobbingEnemies = new List<GameObject>();
        StartCoroutine(SpawnMermaid());
    }

    private IEnumerator SpawnMermaid()
    {
        //ships spawn indefinitely 
        while (numBobbingEnemies > 0)
        {
            yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
            currentBobbingEnemies.Add(Instantiate(bobbingEnemy, new Vector3(Mathf.Round(spawnPos.position.x + Random.Range(minXPosition, maxXPosition)), Mathf.Round(spawnPos.position.y), Mathf.Round(spawnPos.position.z)), Quaternion.identity));
            numBobbingEnemies--;
        }

    }

    private void OnDestroy()
    {
        foreach (GameObject currentMermaid in currentBobbingEnemies)
        {
            Destroy(currentMermaid);
        }
    }
}
