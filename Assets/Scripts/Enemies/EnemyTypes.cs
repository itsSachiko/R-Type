using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyTypes
{
    [SerializeField] public string enemyType;
    [SerializeField] public Transform prefab;
    [SerializeField] public float spawnRate;
    [SerializeField] public int maxHP;
    [SerializeField] public float movementSpeed;
    [SerializeField] public float bulletSpeed; 
    //[SerializeField] public GameObject ;

}
