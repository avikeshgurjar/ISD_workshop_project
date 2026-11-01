using System.Collections;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject bombPrefab;
    public float spawnInterval = 1.2f;
    public float xSpawnRange = 7.5f;
    public float spawnY = 6.0f;
    [Range(0f, 1f)] public float bombSpawnChance = 0.25f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            Vector3 spawnPos = new Vector3(randomX, spawnY, 0f);

            GameObject prefabToSpawn = (Random.value < bombSpawnChance) ? bombPrefab : coinPrefab;
            if (prefabToSpawn != null)
            {
                Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
            }
        }
    }
}
