using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float movementSpeed;
    private float enemyHP;

    public GameManager gameManager;
    
    Spawner spawner;

    UIComponent uiComponent;

     void Start()
    {
        uiComponent = FindAnyObjectByType<UIComponent>();
        gameManager = FindAnyObjectByType<GameManager>();
        spawner = FindAnyObjectByType<Spawner>();



    }
    void Update()
    {
        ChangingStats(gameManager.enemyList[spawner.enemyIndex]);
        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }

    public void ChangingStats(EnemyTypes enemyTypes)
    {
        movementSpeed = enemyTypes.movementSpeed;
        enemyHP =  enemyTypes.maxHP; 
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

        if (collision.transform.CompareTag("Player Bullets"))
        {
            enemyHP--;
            if (enemyHP <= 0)
            {
                gameManager.ChangeEnemy();
                uiComponent.enemyKilledCount++;
                StartCoroutine(Explode());
                uiComponent.ShowingStats();
            }
        }
    }
}
