using UnityEngine;
using UnityEngine.UI;

public class SkinPanel : MonoBehaviour
{
    [SerializeField] private GameObject _mark;

    private void Start()
    {
        int bestLevel = PlayerPrefs.GetInt("maxLevel", 1);
        if (int.Parse(gameObject.transform.GetChild(0).gameObject.name) <= bestLevel)
        {
            gameObject.GetComponent<Button>().enabled = true;
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            if (transform.childCount > 1)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
        }
        else
        {
            gameObject.GetComponent<Button>().enabled = false;
            gameObject.GetComponent<Image>().color = new Color(0.5f, 0.5f, 0.5f, 1);
        }

        string index = PlayerPrefs.GetInt("skinPlane", 0).ToString();
        if (index == gameObject.name) SkinButton();
    }

    public void SkinButton()
    {
        if (MenuManager.Vibrate == 1) Vibration.VibratePop();
        _mark.transform.SetParent(transform, false);
        PlayerPrefs.SetInt("skinPlane", int.Parse(gameObject.name));
    }
}