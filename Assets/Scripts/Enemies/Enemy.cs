using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float movementSpeed;
    private float enemyHP;
    private float movementY;
    private float time;
    private float timeCounted;

    public bool oscillating;


    public GameManager gameManager;
    
    Spawner spawner;

    UIComponent uiComponent;

     void Start()
    {
        uiComponent = FindAnyObjectByType<UIComponent>();
        gameManager = FindAnyObjectByType<GameManager>();
        spawner = FindAnyObjectByType<Spawner>();
        ChangingStats(gameManager.enemyList[spawner.enemyIndex]);
    }
    void Update()
    {
        RandomYMovement();
        //transform.Translate(Vector3.up * movementSpeed * Time.deltaTime);
        transform.Translate(new Vector3(movementY, movementSpeed * Time.deltaTime, 0));
    }

    public void ChangingStats(EnemyTypes enemyTypes)
    {
        movementSpeed = enemyTypes.movementSpeed;
        enemyHP =  enemyTypes.maxHP; 
    }
    private void RandomYMovement() //simula una sinusoide per il movimento in verticale
    {
        
        time += Time.deltaTime; //scala con il tempo idk how to make it costant 

       
        if (oscillating)
        {
            movementY = Mathf.Sin(time * 0.001f) * 1f;
        }
        else
        {
            movementY = -Mathf.Sin(time * 0.001f) * 1f; //1f magnitudine
        }

        
        transform.Translate(Vector3.up * movementY * Time.deltaTime); //2 translate un po' meh but idk

       
        if (transform.position.y >= 0.94f)
        {
            oscillating = false;
        }
        else if (transform.position.y <= -1.29f)
        {
            oscillating = true;
        }
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
