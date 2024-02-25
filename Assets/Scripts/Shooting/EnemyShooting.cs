using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float bulletSpeed = 3f;
    public float fireRate = 1f; 
    private float spawnTime; 

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
