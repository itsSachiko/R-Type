using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIComponent : MonoBehaviour
{
    public GameObject winPanel;
    public GameObject losePanel;

    void Start()
    {
        //winPanel = GetComponent<GameObject>();
        //losePanel = GetComponent<GameObject>();

        winPanel.SetActive(false);
        losePanel.SetActive(false);
    }

    public void tryAgain ()
    {
        SceneManager.LoadScene(0);
    }

    public void OnLose()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }


}
