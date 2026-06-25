using System.Collections;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;
    public Transform spawnPoint;

    public float spawnInterval = 3f;
    public int totalZombies = 5;

    private int spawnedZombies = 0;

    void Start()
    {
        StartCoroutine(SpawnZombies());
    }

    IEnumerator SpawnZombies()
    {
        while (spawnedZombies < totalZombies)
        {
            SpawnZombie();

            spawnedZombies++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnZombie()
    {
        Instantiate(zombiePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}