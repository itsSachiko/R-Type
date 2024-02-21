using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform enemyToSpawn;
    public Transform minPosTransform, maxPosTransform;

    public int spawnRate = 2;

    private float minPosY, maxPosY;
    private float spawnTime;

    void Start()
    {
        minPosY = minPosTransform.position.y;
        maxPosY = maxPosTransform.position.y;

        StartCoroutine(SpawnTime());

    }
    void Update()
    {
        spawnTime += Time.deltaTime;

        if (spawnTime >= spawnRate)
        {
            Vector3 pos = new Vector3(7.65f, Random.Range(minPosY, maxPosY) , transform.position.z);

            //Quaternion rotation = Quaternion.Euler(0, 0, 90);
            Instantiate(enemyToSpawn, pos, Quaternion.identity);
            spawnTime = 0;
        }
    }

    
    IEnumerator SpawnTime() 

    {

        yield return new WaitForSeconds(10);

    }

}
