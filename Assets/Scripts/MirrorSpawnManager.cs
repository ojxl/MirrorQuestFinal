using System.Collections.Generic;   // needed for List<Transform>(Unit5.1 :p)
using UnityEngine;

public class MirrorSpawnManager : MonoBehaviour
{
    [Header("Mirrors")]
    [SerializeField] private GameObject[] mirrorPrefabs;     // dragged mirror prefabs here Unit6
    [SerializeField] private Transform[] mirrorSpawnPoints;  // dragged MirrorSpot_ here
    [SerializeField] private int mirrorsToSpawn = 3;         // brief: 3 randomly placed so 3 it is

    void Start() => SpawnUnique_ListWay();

    // Use a List so we can RemoveAt() and keep locations unique
    void SpawnUnique_ListWay()
    {
        //if no mirrors or spawn points, exit early
        if (mirrorPrefabs == null || mirrorPrefabs.Length == 0) return;//unit 2.3 
        if (mirrorSpawnPoints == null || mirrorSpawnPoints.Length == 0) return;//Unit 4.2

        var available = new List<Transform>(mirrorSpawnPoints);
        int toSpawn = Mathf.Min(mirrorsToSpawn, available.Count); //unit 3 and 5  

        for (int i = 0; i < toSpawn; i++)
        {
            int pointIndex  = Random.Range(0, available.Count); //unit 2.3 
            int prefabIndex = Random.Range(0, mirrorPrefabs.Length);

            Instantiate(mirrorPrefabs[prefabIndex],
                        available[pointIndex].position,
                        available[pointIndex].rotation);

            available.RemoveAt(pointIndex); // keeps spawn points unique
        }
    }
}
