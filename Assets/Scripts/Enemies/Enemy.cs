using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float movementSpeed = 5f;

    private bool canMove;

    void Update()
    {

        transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
    }

    IEnumerator Explode()
    {
        canMove = false;
        //qui posso far partire l'animazione, disattivare il collider dell'enemy
        
        //qui posso aggiungere lo score al player

        //gm.IncrementScore(scoreOnDeath);

        Destroy(gameObject);

        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {

            canMove = false;

            StartCoroutine(Explode());

        }


    }
}
