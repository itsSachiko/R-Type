using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prova : MonoBehaviour
{
    [SerializeField] public float speed = 1f;

    [SerializeField] public float limit = 7.5f;

    private void Update()
    {
        BackgroundInMovement();
        InfiniteTiles();
    }

    void BackgroundInMovement()
    {
        transform.position = new Vector2(transform.position.x - Time.deltaTime * speed, transform.position.y);
    }

    void InfiniteTiles()
    {
        if (transform.position.x <= -limit)
        {
            transform.position = new Vector2(limit, transform.position.y);
        }
    } 

    //va per lo sfondo stellato ma non per le nuvole idk, ma è meglio gestire via array
}