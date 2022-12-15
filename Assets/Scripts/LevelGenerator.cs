using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject glacierPrefab;
    [SerializeField] private float glacierSpeed = 0.4f;
    [SerializeField] private float maxGlacierDistanceAway = 12f;

    [SerializeField] private GameObject borderPrefab;

    [SerializeField] private GameObject waterTerrain;
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private GameObject waterPlane;
    //game object, row size
    [SerializeField] private Queue<KeyValuePair<GameObject, int>> terrainsQueue = new Queue<KeyValuePair<GameObject, int>>();
    [SerializeField] private GameObject player;

    private Vector3 currentPosition = new Vector3(0, 0, -7);
    private List<GameObject> currentTerrains = new List<GameObject>();
    private GameObject inGameWaterPlane;
    private int waterPlaneCounter = 1;
    private GameObject glacier;
    private List<GameObject> currentWaterPlanes = new List<GameObject>();
    private List<GameObject> currentRightBorders = new List<GameObject>();
    private List<GameObject> currentLeftBorders = new List<GameObject>();

    private int terrainCounter = 0;

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
        glacierSpeed = 0.4f;
        gameState = GameState.Ingame;
        glacier = Instantiate(glacierPrefab);
        currentWaterPlanes.Add(Instantiate(waterPlane, new Vector3(0, 0.1f, 0), Quaternion.identity));
        currentRightBorders.Add(Instantiate(borderPrefab, new Vector3(20, 0, 0), Quaternion.identity));
        currentLeftBorders.Add(Instantiate(borderPrefab, new Vector3(-20, 0, 0), Quaternion.identity));

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
        if (playerZPosition >= 20 && playerZPosition < 50)
        {
            glacierSpeed = 0.6f;
        } else if (playerZPosition >= 50 && playerZPosition < 80)
        {
            glacierSpeed = 0.8f;
        } else if (playerZPosition >= 80)
        {
            glacierSpeed = 1f;
        }

        if (currentPosition.z > (waterPlaneCounter-1) * 50)
        {
            currentRightBorders.Add(Instantiate(borderPrefab, new Vector3(20, 0, waterPlaneCounter * 50), Quaternion.identity));
            currentLeftBorders.Add(Instantiate(borderPrefab, new Vector3(-20, 0, waterPlaneCounter * 50), Quaternion.identity));
            currentWaterPlanes.Add(Instantiate(waterPlane, new Vector3(0, 0, waterPlaneCounter * 50), Quaternion.identity));
            waterPlaneCounter++;
            if (currentWaterPlanes.Count > 3)
            {
                GameObject removedWaterPlane = currentWaterPlanes[0];
                currentWaterPlanes.RemoveAt(0);
                Destroy(removedWaterPlane);

                GameObject removedRightBorder = currentRightBorders[0];
                currentRightBorders.RemoveAt(0);
                Destroy(removedRightBorder);

                GameObject removedLeftBorder = currentLeftBorders[0];
                currentLeftBorders.RemoveAt(0);
                Destroy(removedLeftBorder);
            }
        }
        if (currentPosition.z - playerZPosition > maxTerrainCount - 8)
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
            GenerateTerrainQueue(playerZPosition);
        }

        KeyValuePair<GameObject, int> terrainPairFromQueue = terrainsQueue.Dequeue();
        GameObject terrain = Instantiate(terrainPairFromQueue.Key, currentPosition, Quaternion.identity);
        currentPosition.z += terrainPairFromQueue.Value;
        //inGameWaterPlane.transform.localScale += new Vector3(0, 0, 1); 
        currentTerrains.Add(terrain);
    }

    private void GenerateTerrainQueue(float playerZPosition)
    {
        terrainCounter++;
        if (currentPosition.z < 0)
        {
            for (int i = 0; i < 15; i++)
            {
                terrainsQueue.Enqueue(new KeyValuePair<GameObject, int>(waterTerrain, 1));
            }
            return;
        }

        //PROGRESSION WITH EMPTY BARS
        //positions 0-30: every other generated terrain is empty with 2 bars
        //positions 30-100: every other generated terrain is empty with 1 bars
        //positions 100+: no empty bars guaranteed to be generated

        if (playerZPosition < 30 && terrainCounter % 2 == 0)
        {
            terrainsQueue.Enqueue(new KeyValuePair<GameObject, int>(waterTerrain, 1));
            terrainsQueue.Enqueue(new KeyValuePair<GameObject, int>(waterTerrain, 1));
            return;
        }

        if (playerZPosition >= 30 && playerZPosition < 100 && terrainCounter % 2 == 0)
        {
            terrainsQueue.Enqueue(new KeyValuePair<GameObject, int>(waterTerrain, 1));
            return;
        }

        //PROGRESSION WITH BAR TYPES
        //z positions 0-25: normal
        //z positions 25-50: added ships
        //positions 50+: added mermaids and fish

        TerrainData nextTerrainInQueue;
        if (currentPosition.z < 25)
        {
            nextTerrainInQueue = terrainDatas[Random.Range(0, terrainDatas.Count-4)];
        } else if (currentPosition.z < 50)
        {
            nextTerrainInQueue = terrainDatas[Random.Range(0, terrainDatas.Count-2)];
        } else
        {
            nextTerrainInQueue = terrainDatas[Random.Range(0, terrainDatas.Count)];
        }
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
