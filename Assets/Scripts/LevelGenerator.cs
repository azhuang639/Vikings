using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    //game object, row size
    [SerializeField] private Queue<KeyValuePair<GameObject, int>> terrainsQueue = new Queue<KeyValuePair<GameObject, int>>();
    [SerializeField] private GameObject player;

    private Vector3 currentPosition = new Vector3(0, 0, -9);
    private List<GameObject> currentTerrains = new List<GameObject>();

    private enum TerrainType
    {
        Grass,
        Sand,
        Water
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    SpawnTerrain();
        //}
    }

    public void SpawnTerrain(float playerZPosition)
    {
        if (currentPosition.z - playerZPosition > maxTerrainCount - 10)
        {
            return;
        }
        if (currentTerrains.Count >= maxTerrainCount)
        {
            GameObject removedTerrain = currentTerrains[0];
            currentTerrains.RemoveAt(0);
            Destroy(removedTerrain);
        }
        if (terrainsQueue.Count == 0)
        {
            GenerateTerrainQueue();
        }

        KeyValuePair<GameObject, int> terrainPairFromQueue = terrainsQueue.Dequeue();
        GameObject terrain = Instantiate(terrainPairFromQueue.Key, currentPosition, Quaternion.identity);
        currentPosition.z += terrainPairFromQueue.Value;
        currentTerrains.Add(terrain);
    }

    private void GenerateTerrainQueue()
    {
        TerrainData nextTerrainInQueue = terrainDatas[Random.Range(0, terrainDatas.Count)];
        //handles region
        if (nextTerrainInQueue.terrainType == TerrainData.TerrainType.Region)
        {
            terrainsQueue.Enqueue(new KeyValuePair<GameObject, int> (nextTerrainInQueue.region, nextTerrainInQueue.regionRowSize));
            return;
        }

        //handles rows
        GameObject[] nextTerrains = nextTerrainInQueue.GetTerrainRows();
        for (int i = 0; i < nextTerrains.Length; i++)
        {
            terrainsQueue.Enqueue(new KeyValuePair<GameObject, int> (nextTerrains[i], 1));
        }
    }
}
