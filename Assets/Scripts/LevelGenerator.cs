using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject glacierPrefab;
    [SerializeField] private float glacierSpeed = 0.4f;
    [SerializeField] private float maxGlacierDistanceAway = 12f;

    [SerializeField] private GameObject waterTerrain;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private GameObject waterPlane;
    //game object, row size
    [SerializeField] private Queue<KeyValuePair<GameObject, int>> terrainsQueue = new Queue<KeyValuePair<GameObject, int>>();
    [SerializeField] private GameObject player;

    private Vector3 currentPosition = new Vector3(0, 0, -9);
    private List<GameObject> currentTerrains = new List<GameObject>();
    private GameObject inGameWaterPlane;
    private int waterPlaneCounter = 1;
    private GameObject glacier;
    private List<GameObject> currentWaterPlanes = new List<GameObject>();

    private enum GameState
    {
        Ingame,
        Ended
    }

    private enum TerrainType
    {
        Grass,
        Sand,
        Water
    }

    private GameState gameState;

    // Start is called before the first frame update
    void Start()
    {
        gameState = GameState.Ingame;
        glacier = Instantiate(glacierPrefab);
        currentWaterPlanes.Add(Instantiate(waterPlane, new Vector3(0, 0, 0), Quaternion.identity));

        for (int i = 0; i < maxTerrainCount; i++)
        {
            SpawnTerrain(0);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == GameState.Ended)
        {
            return;
        }

        if (player.transform.position.z - glacier.transform.position.z > maxGlacierDistanceAway)
        {
            glacier.transform.position = new Vector3(0,
                1,
                player.transform.position.z - maxGlacierDistanceAway);
        }
        glacier.transform.position = glacier.transform.position + new Vector3(0, 0, glacierSpeed * Time.deltaTime);
    }

    public void SpawnTerrain(float playerZPosition)
    {
        if (currentPosition.z > (waterPlaneCounter-1) * 50)
        {
            currentWaterPlanes.Add(Instantiate(waterPlane, new Vector3(0, 0, waterPlaneCounter * 50), Quaternion.identity));
            waterPlaneCounter++;
            if (currentWaterPlanes.Count > 3)
            {
                GameObject removedWaterPlane = currentWaterPlanes[0];
                currentWaterPlanes.RemoveAt(0);
                Destroy(removedWaterPlane);
            }
        }
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
        //inGameWaterPlane.transform.localScale += new Vector3(0, 0, 1); 
        currentTerrains.Add(terrain);
    }

    private void GenerateTerrainQueue()
    {
        if (currentPosition.z < 0)
        {
            for (int i = 0; i < 15; i++)
            {
                terrainsQueue.Enqueue(new KeyValuePair<GameObject, int>(waterTerrain, 1));
            }
            return;
        }
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

    public void EndGame()
    {
        gameState = GameState.Ended;
    }
}
