using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject Enemy;


    private float despawnDistance;
    private int enemyToCheck;
    public float timeToSpawn;
    private float spawnCounter;

    public int checkPerFrame;

    public Transform miniSpawn, maxSpawn;

    private Transform target;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    public List<WaveInfo> waves;

    private int currentWave;

    private float waveCounter;

    // Start is called before the first frame update
    void Start()
    {
        spawnCounter = timeToSpawn;

        target = playerHealthController.instance.transform;
        despawnDistance = Vector3.Distance(transform.position, maxSpawn.position) + 4f;

        currentWave = -1;
        GoToNextWave();
    }

    // Update is called once per frame
    void Update()
    {
       if (playerHealthController.instance.gameObject.activeSelf)
        {
            if (currentWave < waves.Count)
            {
                waveCounter -= Time.deltaTime;
                if (waveCounter <= 0)
                {
                    GoToNextWave();
                }

                spawnCounter -= Time.deltaTime;
                if (spawnCounter <= 0)
                {
                    spawnCounter = waves[currentWave].timeBetweenSpawns;

                    GameObject newEnemy = Instantiate(waves[currentWave].enemyToSpawn, SelectSpawnPoint(), Quaternion.identity);

                    spawnedEnemies.Add(newEnemy);
                }
            }
        }

        transform.position = target.position;

        int checkTarget = enemyToCheck + checkPerFrame;

        while (enemyToCheck < checkTarget)
        {
            if (enemyToCheck < spawnedEnemies.Count)
            {
                if (spawnedEnemies[enemyToCheck] != null)
                {
                    if (Vector3.Distance(transform.position, spawnedEnemies[enemyToCheck].transform.position) > despawnDistance)
                    {
                        Destroy(spawnedEnemies[enemyToCheck]);

                        spawnedEnemies.RemoveAt(enemyToCheck);
                        checkTarget--;
                    }
                    else
                    {
                        enemyToCheck++;
                    }
                }
                else
                {
                    spawnedEnemies.RemoveAt(enemyToCheck);
                    checkTarget--;
                }
            }
            else
            {
                enemyToCheck = 0;
                checkTarget = 0;
            }
        }
    }
    public Vector3 SelectSpawnPoint()
    {
        Vector3 spawnPoint = new Vector3(-0.1f, 1.708f, -6.036f);

        bool spawnVerticalEdge = Random.Range(0f, 1f) > .5f;

        if (spawnVerticalEdge)
        {
            spawnPoint.y = Random.Range(miniSpawn.position.y, maxSpawn.position.y);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.x = maxSpawn.position.x;
            }
            else
            {
                spawnPoint.x = miniSpawn.position.x;
            }
        }
        else
        {
            spawnPoint.x = Random.Range(miniSpawn.position.x, maxSpawn.position.x);
            if (Random.Range(0f, 1f) > .5f)
            {
                spawnPoint.y = maxSpawn.position.y;
            }
            else
            {
                spawnPoint.y = miniSpawn.position.y;
            }
        }
        return spawnPoint;
    }

    public void GoToNextWave()
    {
        currentWave++;

        if (currentWave >= waves.Count)
        {
            currentWave = waves.Count - 1;
        }

        waveCounter = waves[currentWave].waveLength;
        spawnCounter = waves[currentWave].timeBetweenSpawns;
    }

    [System.Serializable]
    public class WaveInfo
    {
        public GameObject enemyToSpawn;
        public float waveLength = 10f;
        public float timeBetweenSpawns = 1f;
    }

}
