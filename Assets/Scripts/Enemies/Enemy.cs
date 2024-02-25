using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float movementSpeed;
    private float enemyHP;
    
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        movementSpeed = gameManager.enemyList[0].movementSpeed;
        enemyHP = gameManager.enemyList[0].maxHP;
    }
    void Update()
    {
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);

    }

    IEnumerator Explode()
    {   
        Destroy(gameObject);

        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            StartCoroutine(Explode());
        }

        if (collision.transform.CompareTag("Bullet"))
        {
            enemyHP -= 1;
            if (enemyHP == 0)
                StartCoroutine(Explode());
        }
    }
    void Healh()
    {


    }
}
