using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject[] Enemy;
    

    public float timeToSpawn;
    private float spawnTime;

    public Transform miniSpawn, maxSpawn;

    private Transform target;

    private List<GameObject> spawnedEnemies = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = timeToSpawn;

        target = playerHealthController.instance.transform; 
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime <= 0)
        {
            spawnTime = timeToSpawn;

            int randomIndex = Random.Range(0, Enemy.Length);
            GameObject enemyToSpawn = Enemy[randomIndex];

            // Instantiate the selected enemy
            Instantiate(enemyToSpawn, SelectSpawnPointer(), transform.rotation);

        }

        transform.position = target.position;
    }
        public Vector3 SelectSpawnPointer()
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
     
}
