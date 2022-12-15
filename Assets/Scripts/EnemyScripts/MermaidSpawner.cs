using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidSpawner : MonoBehaviour
{
    [SerializeField] private GameObject mermaid;
    [SerializeField] private Transform spawnPos;
    [SerializeField] private float minSeparationTime=2;
    [SerializeField] private float maxSeparationTime = 5;
    [SerializeField] private float minXPosition = -40;
    [SerializeField] private float maxXPosition = 40;
    [SerializeField] private int numMermaids = 20;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnMermaid());

    }

    private IEnumerator SpawnMermaid()
    {
        //ships spawn indefinitely 
        while (numMermaids >0)
        {
            yield return new WaitForSeconds(Random.Range(minSeparationTime, maxSeparationTime));
            Instantiate(mermaid, new Vector3(Mathf.Round(spawnPos.position.x + Random.Range(minXPosition, maxXPosition)), Mathf.Round(spawnPos.position.y), Mathf.Round(spawnPos.position.z)), Quaternion.identity);
            numMermaids--;
        }

    }
}
