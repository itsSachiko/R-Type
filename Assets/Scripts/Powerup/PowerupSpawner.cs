using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public Transform powerupPrefab;
    public Transform minPosTransform, maxPosTransform;

    public int spawnRate = 2;

    private float minPosX, maxPosX;
    private float spawnTime;

    void Start()
    {
        minPosX = minPosTransform.position.x;
        maxPosX = maxPosTransform.position.x;
    }

    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnRate)
        {
            Vector3 pos = new Vector3(Random.Range(minPosX, maxPosX), 1f, transform.position.z);
            Instantiate(powerupPrefab, pos, Quaternion.identity);
            spawnTime = 0;
        }
    }

}
