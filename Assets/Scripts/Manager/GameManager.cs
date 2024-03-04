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
        if (uiComponent.enemyKilledCount <= 1)
        {
            spawner.enemyIndex = 0;
        }

        else if (uiComponent.enemyKilledCount > 1 && uiComponent.enemyKilledCount <= 2)
        {
            spawner.enemyIndex = 1;
        }

        else if (uiComponent.enemyKilledCount > 2 && uiComponent.enemyKilledCount <= 3)
        {
            spawner.enemyIndex = 2;
        }
        else if (uiComponent.enemyKilledCount == 3)
        {
            win.Invoke();
        }
    }
}
