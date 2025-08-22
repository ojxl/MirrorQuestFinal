//Spawns a set number of mirror objects randomly as assigned spawn points
using System.Collections.Generic;   // needed for List<Transform>(Unit5.1 :p)
using UnityEngine;

public class MirrorSpawnManager : MonoBehaviour
{
    //allows me to have headers in the inspector for organization
    [Header("Mirrors")]
    // dragged mirror prefabs here Unit6
    [SerializeField] private GameObject[] mirrorPrefabs; 
     // dragged MirrorSpot_ here
    [SerializeField] private Transform[] mirrorSpawnPoints;
     // brief: 3 randomly placed so 3 it is
    [SerializeField] private int mirrorsToSpawn = 3;        
    void Start() => SpawnUnique_ListWay();

    // Check for valid input like if the mirrors r there or not and 
    // creates a list of available spawn points
    void SpawnUnique_ListWay()
    {
        //if no mirrors or spawn points, exit early
        if (mirrorPrefabs == null || mirrorPrefabs.Length == 0) return;//unit 2.3 
        if (mirrorSpawnPoints == null || mirrorSpawnPoints.Length == 0) return;//Unit 4.2

        // create a list of available spawn points
        List<Transform> available = new List<Transform>(mirrorSpawnPoints);
        int toSpawn = Mathf.Min(mirrorsToSpawn, available.Count); //unit 3 and 5  

        //Spawning loop for mirrors
        for (int i = 0; i < toSpawn; i++)
        {
            //picks random spawn point from the available list
            int pointIndex = Random.Range(0, available.Count); //unit 2.3 and 5.1 available.count is how many spawn points left
            //picks a random mirror prefab from the array
            int prefabIndex = Random.Range(0, mirrorPrefabs.Length);

            //creates the mirror at the chosen spawn point
            Instantiate(mirrorPrefabs[prefabIndex],
                        available[pointIndex].position,
                        available[pointIndex].rotation);

            //Removes spawn point frpm the list so it cant be used again!
            available.RemoveAt(pointIndex); // keeps spawn points unique
        }
    }
}
