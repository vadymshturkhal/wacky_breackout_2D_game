using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject ballPrefab;
    Vector3 spawnPosition = new Vector3(0, -6, 0);
    Vector3 collisionFreeSpawnPosition;

    Timer ballSpawnTimer;
    float balRadius;

    bool retrySpawn = false;
    Vector2 spawnLocationMin = new Vector2(-10, -6);
    Vector2 spawnLocationMax = new Vector2(10, 0);

    void Awake()
    {
        Instantiate<GameObject>(ballPrefab, spawnPosition, Quaternion.identity);
    }

    void Start()
    {
        ballSpawnTimer = gameObject.AddComponent<Timer>();
        StartBallTimer();

        // Spawn and destroy entity to cash collider values
        GameObject tempEntity = Instantiate(ballPrefab) as GameObject;
        CircleCollider2D collider = tempEntity.GetComponent<CircleCollider2D>();
        balRadius = collider.radius;
        Destroy(tempEntity);
    }

    void FixedUpdate()
    {
        if (ballSpawnTimer.Finished && retrySpawn)
        {
            Instantiate<GameObject>(ballPrefab, collisionFreeSpawnPosition, Quaternion.identity);
            retrySpawn = false;
        }
        
        if (!retrySpawn)
        {
            CalculateCollisionFreeLocation();
        }
    }
    
    void StartBallTimer()
    {
        ballSpawnTimer.Duration = GetRandomValue();
        ballSpawnTimer.Run();
    }

    // With random area
    void CalculateCollisionFreeLocation()
    {
        collisionFreeSpawnPosition.x = Random.Range(spawnLocationMin.x, spawnLocationMax.x);
        collisionFreeSpawnPosition.y = Random.Range(spawnLocationMin.y, spawnLocationMax.y);
        collisionFreeSpawnPosition.z = -Camera.main.transform.position.z;
        Vector3 worldLocation = Camera.main.ScreenToWorldPoint(collisionFreeSpawnPosition);

        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) != null)
        {
            // Change collisionFreeSpawnPosition and calculate new rectangle points
            collisionFreeSpawnPosition.x = Random.Range(spawnLocationMin.x, spawnLocationMax.x);
            collisionFreeSpawnPosition.y = Random.Range(spawnLocationMin.y, spawnLocationMax.y);
            worldLocation = Camera.main.ScreenToWorldPoint(collisionFreeSpawnPosition);
        }

        retrySpawn = true;
        StartBallTimer();
    }

    float GetRandomValue()
    {
        float start = ConfigurationUtils.MinSpawnDelay;
        float end = ConfigurationUtils.MaxSpawnDelay;

        float rand = Random.Range(start, end);
        return rand;
    }
}
