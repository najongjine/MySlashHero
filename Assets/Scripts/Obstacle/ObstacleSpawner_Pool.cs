using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner_Pool : MonoBehaviour
{
    List<GameObject> spikePool = new List<GameObject>();
    List<GameObject> swingObsPool = new List<GameObject>();
    List<GameObject> wolfPool = new List<GameObject>();
    List<GameObject> rotateObsPool = new List<GameObject>();
    List<GameObject> healthObjPool = new List<GameObject>();
    int rotateObsPoolIndex = 0;

    [SerializeField]
    private GameObject spikePrefab, swingingObstaclePrefab, wolfPrefab;

    [SerializeField]
    private GameObject[] rotatingObstaclePrefabs;

    [SerializeField]
    private float spikeYPos = -3.5f;

    [SerializeField]
    private float wolfYPos = -3.1f;

    [SerializeField]
    private float rotatingObstacleMinY = -3.3f, rotatingObstacleMaxY = -0.6f;

    [SerializeField]
    private float swingObstacleMinY = 0.7f, swingObstacleMaxY = 3f;

    [SerializeField]
    private float minSpawnWaitTime = 2f, maxSpawnWaitTime = 3.5f;

    private float spawnWaitTime;

    private int obstacleTypesCount = 4;

    private int obstacleToSpawn;

    private Camera mainCam;

    private Vector3 obstacleSpawnPos = Vector2.zero;

    private GameObject newObstacle;

    [SerializeField]
    private GameObject healthPrefab;

    [SerializeField]
    private float minHealthY = -3.3f, maxHealthY = 1f;

    private Vector3 healthSpawnPos = Vector3.zero;

    [SerializeField]
    private int healthSpawnProbability = 6;

    private void Awake()
    {
        mainCam = Camera.main;
    }
    private void Start()
    {
        for (int i = 0; i < 59; i++)
        {
            var obj = Instantiate(rotatingObstaclePrefabs[Random.Range(0, rotatingObstaclePrefabs.Length)]);
            obj.SetActive(false);
            rotateObsPool.Add(obj);
        }
    }

    private void Update()
    {
        HandleObstacleSpawning();
    }

    void HandleObstacleSpawning()
    {

        if (Time.time > spawnWaitTime)
        {
            spawnWaitTime = Time.time + Random.Range(minSpawnWaitTime, maxSpawnWaitTime);
            SpawnObstacle();
            SpawnHealth();
        }

    }

    void SpawnObstacle()
    {

        obstacleToSpawn = Random.Range(0, obstacleTypesCount);

        obstacleSpawnPos.x = mainCam.transform.position.x + 20f;
        var bCreateNew = true;
        switch (obstacleToSpawn)
        {

            case 0:
                foreach (var obj in spikePool)
                {
                    if (!obj.activeInHierarchy)
                    {
                        newObstacle = obj;
                        newObstacle.SetActive(true);
                        bCreateNew = false;
                        break;
                    }
                }
                if (bCreateNew)
                {
                    newObstacle = Instantiate(spikePrefab);
                }
                obstacleSpawnPos.y = spikeYPos;
                break;

            case 1:
                foreach (var obj in swingObsPool)
                {
                    if (!obj.activeInHierarchy)
                    {
                        newObstacle = obj;
                        newObstacle.SetActive(true);
                        bCreateNew = false;
                        break;
                    }
                }
                if (bCreateNew)
                {
                    newObstacle = Instantiate(swingingObstaclePrefab);
                }

                obstacleSpawnPos.y = Random.Range(swingObstacleMinY, swingObstacleMaxY);
                break;

            case 2:
                foreach (var obj in wolfPool)
                {
                    if (!obj.activeInHierarchy)
                    {
                        newObstacle = obj;
                        newObstacle.SetActive(true);
                        bCreateNew = false;
                        break;
                    }
                }
                if (bCreateNew)
                {
                    newObstacle = Instantiate(wolfPrefab);
                }
                obstacleSpawnPos.y = wolfYPos;
                break;

            case 3:

                newObstacle = rotateObsPool[rotateObsPoolIndex];
                newObstacle.SetActive(true);

                obstacleSpawnPos.y = Random.Range(rotatingObstacleMinY, rotatingObstacleMaxY);
                rotateObsPoolIndex++;
                if (rotateObsPoolIndex >= rotateObsPool.Count)
                {
                    rotateObsPoolIndex = 0;
                }
                break;
        }

        newObstacle.transform.position = obstacleSpawnPos;

    }
    void SpawnHealth()
    {
        if (Random.Range(0, 10) > healthSpawnProbability)
        {
            var bCreateNew = true;
            healthSpawnPos.x = mainCam.transform.position.x + 30f;
            healthSpawnPos.y = Random.Range(minHealthY, maxHealthY);
            foreach (var obj in healthObjPool)
            {
                if (!obj.activeInHierarchy)
                {
                    bCreateNew = false;
                    obj.transform.position = healthSpawnPos;
                    obj.SetActive(true);
                }
            }
            if (bCreateNew)
            {
                Instantiate(healthPrefab, healthSpawnPos, Quaternion.identity);
            }
        }
    }


}
