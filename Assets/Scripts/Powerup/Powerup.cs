using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float prefabSpeed = 1f;
    public float timer = 5f;
    public float newMovementSpeed = 5f;
    private float originalSpeed;

    private PlayerMovement playerMovement;

    private SpriteRenderer spriteRenderer;
    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSpeed = playerMovement.speed; 
    }

    private void Update()
    {
        transform.Translate(Vector3.down * prefabSpeed * Time.deltaTime);
    }

    IEnumerator Explode()
    {
        Destroy(gameObject);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ActivatePowerup());
            Hide();
            
        }
        else if (collision.CompareTag("Wall"))
        {
            StartCoroutine(Explode());
        }
    }

    IEnumerator ActivatePowerup()
    {
        

        playerMovement.speed = newMovementSpeed;
        Debug.Log("original: " + originalSpeed + "player.speed " + playerMovement.speed);

        Debug.Log("timer:" + timer);
        yield return new WaitForSeconds(timer);

        playerMovement.speed = originalSpeed;
        Debug.Log("original: " + originalSpeed+ "player.speed " + playerMovement.speed);
       
        
    }

    void Hide()
    {
        spriteRenderer.enabled = false;
    }
}
