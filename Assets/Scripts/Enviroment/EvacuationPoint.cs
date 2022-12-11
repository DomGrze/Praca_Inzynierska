using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EvacuationPoint : MonoBehaviour
{
    public GameObject winMenu;
    
    void OnTriggerEnter2D(Collider2D other)
    {
        winMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
    }
    public void Continue()
    {
        winMenu.SetActive(false);
        Time.timeScale = 1f;
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
        }

    }
}
