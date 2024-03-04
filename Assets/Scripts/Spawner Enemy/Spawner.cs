using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform minPosTransform, maxPosTransform;

    public GameManager gameManager;

    [HideInInspector] public int enemyIndex;

    float spawnRate;
    private float minPosY, maxPosY;
    float spawnTime;

    void Start()
    {
        minPosY = minPosTransform.position.y;
        maxPosY = maxPosTransform.position.y;

    }
    void Update()
    {
        SpawnSystem(gameManager.enemyList[enemyIndex]); 
    }

    void SpawnSystem(EnemyTypes enemyTypes)
    {
        spawnRate = enemyTypes.spawnRate;
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnRate)
        {
            Vector3 pos = new Vector3(transform.position.x, Random.Range(minPosY, maxPosY), transform.position.z);
            Instantiate(gameManager.enemyList[enemyIndex].prefab, pos, Quaternion.identity);
            spawnTime = 0;
        }
    }

}