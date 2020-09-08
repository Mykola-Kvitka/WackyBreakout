using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;
    private Timer spawnTimer;

    bool retrySpawn = false;
    Vector2 spawnLocationMin;
    Vector2 spawnLocationMax;

    private void Start()
    {

        spawnTimer = gameObject.GetComponent<Timer>();
        spawnTimer.Duration = Randomdeley();
        spawnTimer.Run();

        GameObject tempBall = Instantiate<GameObject>(ballPrefab);
        BoxCollider2D collider = tempBall.GetComponent<BoxCollider2D>();
        float ballColliderHalfWidth = collider.size.x / 2;
        float ballColliderHalfHeight = collider.size.y / 2;
        spawnLocationMin = new Vector2(
            tempBall.transform.position.x - ballColliderHalfWidth,
            tempBall.transform.position.y - ballColliderHalfHeight);
        spawnLocationMax = new Vector2(
            tempBall.transform.position.x + ballColliderHalfWidth,
            tempBall.transform.position.y + ballColliderHalfHeight);
        Destroy(tempBall);

        Instantiate(ballPrefab);
        EventManager.AddZeroListener(EventName.SpawnBall, Spawner);
    }
    private void Update()
    {

         SpawnRange();
        if (retrySpawn)
        {
            Spawner();
        }

    }
    private void SpawnRange()
    {
        float radius = ballPrefab.GetComponent<CircleCollider2D>().radius;
        Collider2D[] checkResult = Physics2D.OverlapCircleAll(ballPrefab.transform.position, radius + 1);
        if (spawnTimer.Finished && checkResult.Length == 0)
        {
            Spawner();
            spawnTimer.Duration = Randomdeley();
            spawnTimer.Run();
        }

    }
    private void Spawner()
    {

        if (Physics2D.OverlapArea(spawnLocationMin, spawnLocationMax) == null)
        {
            retrySpawn = false;
            Instantiate(ballPrefab);
        }
        else
        {
            retrySpawn = true;
        }

        

    }
    private float Randomdeley()
    {
        return (float)Random.Range(ConfigurationUtils.MinimumSpawnDelay,
        ConfigurationUtils.MaximumSpawnDelay);
    }
}
