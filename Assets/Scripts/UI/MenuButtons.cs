using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuButtons : MonoBehaviour
{
    public GameObject playButton;
    public GameObject continueButton;
    public bool gameActive;


    private void Awake()
    {
        continueButton.SetActive(false);
        playButton.SetActive(true);
    }

    private void Start()
    {
        if(gameActive)
        {
            continueButton.SetActive(true);
            playButton.SetActive(false);
        }
    }


    public void PlayGame()
    {
        gameActive = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        playButton.SetActive(false);
        continueButton.SetActive(true);
        Time.timeScale = 1;
    }

    public void ContinueGame()
    {
        //GameManager.instance.SpawnEnemyAfterPause();
        GameManager.instance.menu.SetActive(false);
        Time.timeScale = 1;
        FindObjectOfType<AudioManager>().Play("gameMusic");
        FindObjectOfType<AudioManager>().Pause("menuMusic");
    }

    public void RestartGame()
    {
        gameActive = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        playButton.SetActive(true);
        continueButton.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
