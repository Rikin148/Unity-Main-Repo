using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject gameUI;
    public GameObject howToPlayPanel;
    public GameObject gameOverPanel;
    public GameManager gameManager;
    public GameTimer timer;
    public GameObject player;
    public GameFacade gameFacade;

    public void StartGame()
    {
        Time.timeScale = 1f;

        mainMenu.SetActive(false);
        howToPlayPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        gameUI.SetActive(true);

        if (gameFacade != null)
            gameFacade.ResetGame();

        if (timer != null)
        {
            timer.StartTimer();
        }

        if (gameManager != null)
        {
            gameManager.StartGame();
        }
    }

    public void ShowHowToPlay()
    {
        howToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        howToPlayPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;

        gameUI.SetActive(false);
        howToPlayPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        mainMenu.SetActive(true);

        if (timer != null)
            timer.StopTimer();
    }
}