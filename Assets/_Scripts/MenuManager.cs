using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private GameObject _levelsPanel;

    [SerializeField] private GameObject _onIcon;
    [SerializeField] private GameObject _offIcon;

    private void Start()
    {
        Time.timeScale = 1;
        AudioListener.volume = PlayerPrefs.GetFloat("music", 1);
        if (AudioListener.volume == 0)
        {
            _onIcon.SetActive(false);
            _offIcon.SetActive(true);
        }
        else
        {
            _onIcon.SetActive(true);
            _offIcon.SetActive(false);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
        PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("maxLevel", 1));
    }

    public void OpenSkinsPanel()
    {
        _skinsPanel.SetActive(true);
    }

    public void CloseSkinsPanel()
    {
        _skinsPanel.SetActive(false);
    }

    public void OpenLevels()
    {
        _levelsPanel.SetActive(true);
    }

    public void CloseLevelsPanel()
    {
        _levelsPanel.SetActive(false);
    }

    public void OffSound()
    {
        _onIcon.SetActive(false);
        _offIcon.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("music", 0);
    }

    public void OnSound()
    {
        _onIcon.SetActive(true);
        _offIcon.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("music", 1);
    }
}