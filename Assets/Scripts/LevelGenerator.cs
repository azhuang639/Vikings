using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int maxTerrainCount;
    [SerializeField] private List<TerrainData> terrainDatas = new List<TerrainData>();
    [SerializeField] private Queue<GameObject> terrainsQueue = new Queue<GameObject>();
    [SerializeField] private GameObject player;
    //[SerializeField] private Camera mainCamera;

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

        GameObject terrain = Instantiate(terrainsQueue.Dequeue(), currentPosition, Quaternion.identity);
        currentPosition.z++;
        //Vector3 oldPosition = mainCamera.transform.position;
        //Vector3 newPosition = new Vector3(oldPosition.x, oldPosition.y, oldPosition.z + 1);
        //mainCamera.transform.position = newPosition;
        currentTerrains.Add(terrain);
    }

    private void GenerateTerrainQueue()
    {
        TerrainData nextTerrainInQueue = terrainDatas[Random.Range(0, terrainDatas.Count)];
        int rowsInQueue = Random.Range(1, nextTerrainInQueue.maxRows);
        for (int i = 0; i < rowsInQueue; i++)
        {
            terrainsQueue.Enqueue(nextTerrainInQueue.terrain);
        }
    }
}
