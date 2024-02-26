using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 3f;
    public float fireRate; 
    private float spawnTime;

    GameManager gameManager;


    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        fireRate = gameManager.enemyList[0].fireRate;
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
        rb.velocity = -transform.right * bulletSpeed; 
    }

}
