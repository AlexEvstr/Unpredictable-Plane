using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private GameObject _levelsPanel;

    [SerializeField] private GameObject _onIcon;
    [SerializeField] private GameObject _offIcon;

    [SerializeField] private GameObject _onVibroIcon;
    [SerializeField] private GameObject _offVibroIcon;
    [SerializeField] private GameObject _tutorial;

    public static int Vibrate;

    private void Start()
    {
        Time.timeScale = 1;
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        Vibration.Init();
        Vibrate = PlayerPrefs.GetInt("vibro", 1);
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
        if (Vibrate == 1) Vibration.VibratePop();
        SceneManager.LoadScene("GameScene");
        PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("maxLevel", 1));
    }

    public void OpenSkinsPanel()
    {
        if (Vibrate == 1) Vibration.VibratePop();
        _skinsPanel.SetActive(true);
    }

    public void CloseSkinsPanel()
    {
        if (Vibrate == 1) Vibration.VibratePop();
        _skinsPanel.SetActive(false);
    }

    public void OpenLevels()
    {
        if (Vibrate == 1) Vibration.VibratePop();
        _levelsPanel.SetActive(true);
    }

    public void CloseLevelsPanel()
    {
        if (Vibrate == 1) Vibration.VibratePop();
        _levelsPanel.SetActive(false);
    }

    public void OffSound()
    {
        if (Vibrate == 1) Vibration.VibratePop();
        _onIcon.SetActive(false);
        _offIcon.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("music", 0);
    }

    public void OnSound()
    {
        if (Vibrate == 1) Vibration.VibratePop();
        _onIcon.SetActive(true);
        _offIcon.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("music", 1);
    }

    public void OffVibro()
    {
        _onVibroIcon.SetActive(false);
        _offVibroIcon.SetActive(true);
        Vibrate = 0;
        PlayerPrefs.SetFloat("vibro", Vibrate);
    }

    public void OnVibro()
    {
        if (Vibrate == 1) Vibration.VibratePop();
        _onVibroIcon.SetActive(true);
        _offVibroIcon.SetActive(false);
        Vibrate = 1;
        PlayerPrefs.SetFloat("vibro", Vibrate);
    }

    public void OpenTutorial()
    {
        if (Vibrate == 1) Vibration.VibratePop();
        _tutorial.SetActive(true);
    }

    public void CloseTutorial()
    {
        if (Vibrate == 1) Vibration.VibratePop();
        _tutorial.SetActive(false);
    }
}