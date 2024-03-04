using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIComponent : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    [HideInInspector] public int playerHP;
    [HideInInspector] public int enemyKilledCount;

    public TMP_Text showingHealth;
    public TMP_Text enemyKilled;

    public Health health;


    void Start()
    {
        winPanel.SetActive(false);
        losePanel.SetActive(false);

        playerHP = health.playerHP;
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void OnWin()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }
    public void OnLose()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }

    public void ShowingStats()
    {
        showingHealth.text = ("HP player: ") + playerHP.ToString();
        enemyKilled.text = ("Enemy Killed: ") + enemyKilledCount.ToString();

    }



}
