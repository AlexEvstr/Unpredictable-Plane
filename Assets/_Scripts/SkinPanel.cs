using UnityEngine;

public class SkinPanel : MonoBehaviour
{
    [SerializeField] private GameObject _mark;

    private void Start()
    {
        string index = PlayerPrefs.GetInt("skinPlane", 0).ToString();
        if (index == gameObject.name) SkinButton();
    }

    public void SkinButton()
    {
        _mark.transform.SetParent(transform, false);
        PlayerPrefs.SetInt("skinPlane", int.Parse(gameObject.name));
    }
}