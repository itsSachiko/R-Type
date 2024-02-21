using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundComponent : MonoBehaviour
{

    [SerializeField] private float speed = 1f;
    [SerializeField] private float limit = 6.5f;
    [SerializeField] private Transform[] tiles;

    [SerializeField] float tileWidth; 

    private void Start()
    {
        if (tiles.Length > 0)
        {
            // calcola la larghezza della singola tile -> se gli do io la lunghezza non va idk why 
            tileWidth = tiles[0].GetComponent<SpriteRenderer>().bounds.size.x;
        }
    }

    private void Update()
    {
        BackgroundInMovement();
        UpdateTilesPosition();
    }

    private void BackgroundInMovement()
    {
        transform.position = new Vector2(transform.position.x - Time.deltaTime * speed, transform.position.y);
    }

    private void UpdateTilesPosition()
    {
        foreach (var tile in tiles) //per ogni tile in tiles
        {
            MoveTile(tile);
        }
    }

    private void MoveTile(Transform tile)
    {
        tile.position = new Vector2(tile.position.x - Time.deltaTime * speed, tile.position.y);

        if (tile.position.x <= -limit)
        {
            float mostRightX = FindMostRightPosTile() + tileWidth; // aggiorna ogni volta il calcolo della nuova posizione x
            tile.position = new Vector2(mostRightX, tile.position.y);
        }
    }

    private float FindMostRightPosTile()
    {
        float maxX = float.MinValue;
        foreach (var tile in tiles) //a quanto pare nemmeno qui funge se gl do io la posizione a mano 
        {
            maxX = Mathf.Max(maxX, tile.position.x);
        }
        return maxX;
    }

}
