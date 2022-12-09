using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    private Vector3 currentPosition = new Vector3(0, 0, 0);

    [SerializeField] private List<GameObject> terrains = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        SpawnTerrain();
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
        Instantiate(terrains[Random.Range(0, terrains.Count)], currentPosition,
            Quaternion.identity);
        currentPosition.z++;
    }
}
