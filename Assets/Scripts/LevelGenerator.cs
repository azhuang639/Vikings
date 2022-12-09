using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<GameObject> terrains = new List<GameObject>();

    private Vector3 currentPosition = new Vector3(0, 0, 0);
    private List<GameObject> currentTerrains = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            SpawnTerrain();
        }
    }

    private void SpawnTerrain()
    {
        if (currentTerrains.Count >= maxTerrainCount)
        {
            GameObject removedTerrain = currentTerrains[0];
            currentTerrains.RemoveAt(0);
            Destroy(removedTerrain);
        }
        GameObject terrain = Instantiate(terrains[Random.Range(0, terrains.Count)], currentPosition,
            Quaternion.identity);
        currentPosition.z++;
        currentTerrains.Add(terrain);

    }
}
