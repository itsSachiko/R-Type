using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float movementSpeed;
    private float enemyHP;
    
    GameManager gameManager;

    UIComponent uiComponent;

    private void Start()
    {
        uiComponent = FindAnyObjectByType<UIComponent>();
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
            enemyHP --;
            if (enemyHP == 0)
            {
                uiComponent.enemyKilledCount++;
                StartCoroutine(Explode());
                Debug.Log(uiComponent.enemyKilledCount);
                uiComponent.ShowingStats();
            }
        }
    }
}
