using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public UnityEvent win;
    public UnityEvent lose;
    
    UIComponent uiComponent; 

    Spawner spawner;

    public List<EnemyTypes> enemyList = new List<EnemyTypes>();

    private void Start()
    {
        uiComponent = FindAnyObjectByType<UIComponent>();
        spawner = FindAnyObjectByType<Spawner>();
    }

    public void ChangeEnemy()
    {
        if (uiComponent.enemyKilledCount <= 10)
        {
            spawner.enemyIndex = 0;
        }

        else if (uiComponent.enemyKilledCount > 10 && uiComponent.enemyKilledCount <= 20)
        {
            spawner.enemyIndex = 1;
        }

        else if (uiComponent.enemyKilledCount > 20 && uiComponent.enemyKilledCount <= 30)
        {
            spawner.enemyIndex = 2;
        }
    }
}
