using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private void Start()
    {
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void PauseGame()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}