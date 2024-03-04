using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public float damage;

    IEnumerator Explode()
    {
        Destroy(gameObject);

        yield return null;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //switch (collision.transform.tag)
        //{
        //    case "Wall":
        //    case "Bullet":
        //    case "Enemy": 
        //        StartCoroutine(Explode());
        //        break;
        //    default:
        //        break;
        //}
        StartCoroutine(Explode());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(Explode());
    }



}
