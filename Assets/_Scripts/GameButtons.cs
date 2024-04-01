using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private TMP_Text _levelText;
    private int _currentLevel;

    private void Start()
    {
        Time.timeScale = 1;
        _currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        _levelText.text = $"Level: {_currentLevel}";
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

    public void NextLevel()
    {
        _currentLevel++;
        PlayerPrefs.SetInt("currentLevel", _currentLevel);
        SceneManager.LoadScene("GameScene");
    }
}