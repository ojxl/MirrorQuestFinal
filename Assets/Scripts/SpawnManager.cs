using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("Gems")]
    [SerializeField] GameObject[] MirrorPrefabs;     // your gem prefabs
    [SerializeField] Transform[] MirrorSpawnPoints;  // your GemSpot_ transforms
    [SerializeField] int MirrorsToSpawn = 3;         // spawn exactly 3

    void Start()
    {
        SpawnUniqueNoLists(MirrorPrefabs, MirrorSpawnPoints, MirrorsToSpawn);
    }

    // Each time we pick a random spot from the "available" head of the array,
    // spawn there, swap it to the tail, and shrink the available range.
    void SpawnUniqueNoLists(GameObject[] prefabs, Transform[] points, int count)
    {
        if (prefabs == null || prefabs.Length == 0) return;
        if (points == null || points.Length == 0) return;

        // Shallow copy so we can reorder without touching the original Inspector array
        Transform[] pool = (Transform[])points.Clone();
        int available = pool.Length;

        int toSpawn = Mathf.Min(count, available);
        for (int n = 0; n < toSpawn; n++)
        {
            // pick any index from the available range [0, available)
            int i = Random.Range(0, available);
            int prefabIndex = Random.Range(0, prefabs.Length);

            Instantiate(prefabs[prefabIndex], pool[i].position, pool[i].rotation);

            // swap used element to the end, shrink available by one
            available--;
            Transform tmp = pool[i];
            pool[i] = pool[available];
            pool[available] = tmp;
        }
    }
}
