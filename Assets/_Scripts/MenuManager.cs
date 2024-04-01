using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private GameObject _levelsPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
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
}