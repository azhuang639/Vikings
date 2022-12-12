using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Terrain Data", menuName = "Terrain Data")]
public class TerrainData : ScriptableObject
{
    public enum TerrainType
    {
        SingleRow,
        MultiRow
    }

    public TerrainType terrainType = TerrainType.SingleRow;

    public GameObject terrain;
    public int maxRows;

    public GameObject[] multipleTerrains;

    public GameObject[] GetTerrains()
    {
        if (terrainType == TerrainType.SingleRow)
        {
            GameObject[] terrains = new GameObject[Random.Range(1, maxRows)];
            for (int i = 0; i < terrains.Length; i++)
            {
                terrains[i] = terrain;
            }
            return terrains;
        }

        if (terrainType == TerrainType.MultiRow)
        {
            return multipleTerrains;
        }

        Debug.Log("Terrain doesn't have a terrain type!");
        return new GameObject[0];
    }
}
