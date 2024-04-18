using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameButtons : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private TMP_Text _levelText;
    public static int CurrentLevel;
    public static int MaxLevel;

    private void Start()
    {
        Time.timeScale = 1;
        CurrentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        MaxLevel = PlayerPrefs.GetInt("maxLevel", 1);
        _levelText.text = $"Level: {CurrentLevel}";
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