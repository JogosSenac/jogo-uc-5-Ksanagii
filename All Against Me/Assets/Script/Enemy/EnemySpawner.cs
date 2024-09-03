using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public List<EnemyGroup> enemyGroups; // a lista de grupos de inimigos para spawnar
        public int waveQuota; // o numero total de inimigos para spawnar nesta wave
        public float spawnInterval; // o intervalo de spawn de cada inimigo
        public int spawnCount; // o numero de inimigos ja spawnado nesta wave
    }
    [System.Serializable]
    public class EnemyGroup
    {
        public GameObject enemyPrefab;
        public string enemyName;
        public int enemyCount; // numero de inimigos para spawnar nessa wave
        public int spawnCount; // numero de inimigos ja spawnados
    }

    public List<Wave> waves;
    public int currentWaveCount; // e um indexador para ter de referencia qual a lista atual [comeca de 0]

    [Header("Spawn Atributes")]
    float spawnTimer;
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached;
    public float waveInterval;

    [Header("Spawn Positions")]
    public List<Transform> relativeSpawnPositions;

    Transform player;

    private void Start()
    {
        player = FindObjectOfType<PlayerStats>().transform;
        CalculateWaveQuota();
    }

    private void Update()
    {
        if(currentWaveCount < waves.Count && waves[currentWaveCount].spawnCount == 0)
        {
            StartCoroutine(beginNextWave());
        }

        spawnTimer += Time.deltaTime;
        
        if (spawnTimer >= waves[currentWaveCount].spawnInterval)
        {
            spawnTimer = 0;
            spawnEnemies();
            
        }
    }

    IEnumerator beginNextWave()
    {
        yield return new WaitForSeconds(waveInterval);

        if(currentWaveCount < waves.Count - 1)
        {
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    void CalculateWaveQuota()
    {
        int currentWaveQuota = 0;
        foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
        {
            currentWaveQuota += enemyGroup.enemyCount;
        }

        waves[currentWaveCount].waveQuota = currentWaveQuota;
        Debug.LogWarning(currentWaveQuota);
    }

    void spawnEnemies()
    {
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached)
        {
            foreach(var enemyGroup in waves[currentWaveCount].enemyGroups)
            {
                if(enemyGroup.spawnCount < enemyGroup.enemyCount)
                {
                    if (enemiesAlive >= maxEnemiesAllowed)
                    {
                        maxEnemiesReached = true;
                        return;
                    }

                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPositions[Random.Range(0, relativeSpawnPositions.Count)].position, Quaternion.identity);

                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                    enemiesAlive++;
                }
            }
        }
        if(enemiesAlive < maxEnemiesAllowed)
        {
            maxEnemiesReached = false;
        }
    }

    public void OnKilledEnemy()
    {
        enemiesAlive--;
    }

}
