using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarsCount : MonoBehaviour
{
    [SerializeField] private TMP_Text starsText;

    public static int countOfStars;

    private void Start()
    {
        countOfStars = 0;
    }

    private void Update()
    {
        starsText.text = $"{countOfStars}/10";
    }
}
