//using System.Collections;
//using System.Collections.Generic;
//using UnityEditor;
//using UnityEngine;

//[CustomEditor(typeof(TerrainData))]
//[CanEditMultipleObjects]
//public class TerrainDataEditor : Editor
//{
//    SerializedProperty terrainType;

//    //Single Row
//    SerializedProperty terrain;
//    SerializedProperty maxRows;

//    //Multiple Rows
//    SerializedProperty multipleTerrains;

//    //Region
//    SerializedProperty region;
//    SerializedProperty regionRowSize;

//    void OnEnable()
//    {
//        terrainType = serializedObject.FindProperty("terrainType");
//        terrain = serializedObject.FindProperty("terrain");
//        maxRows = serializedObject.FindProperty("maxRows");
//        multipleTerrains = serializedObject.FindProperty("multipleTerrains");
//        region = serializedObject.FindProperty("region");
//        regionRowSize = serializedObject.FindProperty("regionRowSize");

//    }

//    public override void OnInspectorGUI()
//    {
//        serializedObject.Update();
//        EditorGUILayout.PropertyField(terrainType);
//        //single row
//        if (terrainType.enumValueIndex == 0)
//        {
//            EditorGUILayout.PropertyField(terrain);
//            EditorGUILayout.PropertyField(maxRows);
//        } else if (terrainType.enumValueIndex == 1)
//        {
//            //multi row
//            EditorGUILayout.PropertyField(multipleTerrains);
//        } else if (terrainType.enumValueIndex == 2)
//        {
//            //region
//            EditorGUILayout.PropertyField(region);
//            EditorGUILayout.PropertyField(regionRowSize);
//        }
//        serializedObject.ApplyModifiedProperties();
//    }
//}
