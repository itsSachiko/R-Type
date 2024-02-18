using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocità di movimento del giocatore

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Otteniamo il componente Rigidbody2D del giocatore
    }

    void Update()
    {
        // Otteniamo l'input per il movimento orizzontale e verticale
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcoliamo la velocità di movimento del giocatore
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed;

        // Applichiamo la velocità di movimento al rigidbody del giocatore
        rb.velocity = movement;

    }
}
