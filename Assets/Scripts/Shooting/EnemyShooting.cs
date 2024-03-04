using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 3f;
    public float fireRate; 
    private float spawnTime;

    GameManager gameManager;

    Spawner spawner;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        spawner = FindAnyObjectByType<Spawner>();
        ChangingStats(gameManager.enemyList[spawner.enemyIndex]);
    }
    void Update()
    {
        spawnTime += Time.deltaTime;
        if (spawnTime >= fireRate)
        {
            Shoot();
            spawnTime = 0;
        }
    }

    void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * bulletSpeed; 
    }
    public void ChangingStats(EnemyTypes enemyTypes)
    {
        fireRate = enemyTypes.fireRate;
        bulletSpeed = enemyTypes.bulletSpeed;
        fireRate = enemyTypes.bulletSpeed;
    }

}
