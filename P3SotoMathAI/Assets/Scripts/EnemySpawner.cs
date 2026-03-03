using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnRadius = 6f;
    public float respawnDelay = 2f;

    private GameObject currentEnemy;

    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        if (currentEnemy == null)
        {
            Invoke(nameof(SpawnEnemy), respawnDelay);
        }
    }

    void SpawnEnemy()
    {
        Vector2 spawnPosition = (Vector2)player.position + Random.insideUnitCircle * spawnRadius;

        currentEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Assign player target to AI
        currentEnemy.GetComponent<MathAI>().target = player;
    }
}


