using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject Regular;
    public GameObject Speedy;
    public GameObject Bouncin;
    [Space]
    public float RegularInterval = 3.5f;
    public float SpeedyInterval = 10f;
    public float BouncinInterval = 5f;
    [Space]
    public GameObject SpawnEffect;
    public bool isSpawning = true;
    public Vector2 SpawnArena;
    Transform player;

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (isSpawning)
        {
            StartCoroutine(spawnEnemy(RegularInterval, Regular));
            StartCoroutine(spawnEnemy(SpeedyInterval, Speedy));
            StartCoroutine(spawnEnemy(BouncinInterval, Bouncin));
        }

    }

    IEnumerator spawnEnemy(float Interval, GameObject enemy)
    {
        Vector3 position = GenerateRandomPosition();

        position += player.position;

        yield return new WaitForSeconds(Interval);
        GameObject newEnemy = Instantiate(enemy, position, Quaternion.identity);
        Instantiate(SpawnEffect, position, Quaternion.identity);
        newEnemy.transform.parent = transform;
        if (isSpawning)
        {
            StartCoroutine(spawnEnemy(Interval, enemy));
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        Vector3 position = new Vector3();

        float f = Random.value > 0.5f ? -1f : 1f;
        if (Random.value > 0.5f)
        {
            position.x = Random.Range(-SpawnArena.x,SpawnArena.x);
            position.y = SpawnArena.y * f;
        }
        else
        {
            position.y = Random.Range(-SpawnArena.y,SpawnArena.y);
            position.x = SpawnArena.x * f;
        }

        position.z = 0;

        return position;
    }
}
