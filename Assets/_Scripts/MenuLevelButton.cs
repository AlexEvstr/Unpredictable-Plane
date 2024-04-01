using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuLevelButton : MonoBehaviour
{
    private void Start()
    {
        int levelIndex = PlayerPrefs.GetInt("maxLevel", 1);
        int index = int.Parse(gameObject.name);
        if (index <= levelIndex)
        {
            gameObject.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        }
        else
        {
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = Color.grey;
        }
    }

    public void ClickOnLevel()
    {
        int index = int.Parse(gameObject.name);
        PlayerPrefs.SetInt("currentLevel", index);
        SceneManager.LoadScene("GameScene");
    }
}
