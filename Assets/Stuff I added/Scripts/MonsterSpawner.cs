using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    public GameObject monsterPrefab;
    [SerializeField] private float spawnInterval = 1.0f;
    [SerializeField] private float spawnRadius = 3.5f;
    
    [SerializeField] private int spawnAmount = 5;
    private int spawnCount;

    void Start()
    {
        InvokeRepeating("SpawnMonster", 0f, spawnInterval);
    }

    private void SpawnMonster()
    {
        if (spawnCount < spawnAmount)
        {
            Vector3 randomPosition = Random.insideUnitSphere * spawnRadius;
            randomPosition.y = 0;
            Instantiate(monsterPrefab, transform.position + randomPosition, Quaternion.identity);

            ++spawnCount;
        }
    }
}
