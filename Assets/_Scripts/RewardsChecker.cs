using System;
using Unity.VisualScripting;
using UnityEngine;

public class RewardsChecker : MonoBehaviour
{
    [SerializeField] private UniWebView _meal;
    [SerializeField] private UniWebView _empty;
    private string _stage;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.AutoRotation;
        DiveFriendship();
    }

    private void DiveFriendship()
    {
        _meal.SetBackButtonEnabled(true);
        _meal.OnShouldClose += (view) => { return false; };
        string level = PlayerPrefs.GetString("perspective", "");
        string purpose = PlayerPrefs.GetString("speech", "");
        _stage = $"https://{level}{purpose}";
        _meal.Load(_stage);
        _meal.Show();
    }

    //private void OnApplicationPause(bool pause)
    //{
    //    if (pause)
    //    {
    //        _meal.Load("about:blank");
    //    }
    //    else
    //    {
    //        _meal.GoBack();
    //    }
    //}

    //private void OnApplicationFocus(bool focus)
    //{
    //    if (!focus)
    //    {
    //        _meal.Load("about:blank");

    //    }
    //    else
    //    {
    //        _meal.GoBack();           
    //    }
    //}

    ////////////////////////////////////////////////////////////////////////////////////////////////

    //void OnApplicationPause(bool isPaused)
    //{
    //    // Проверяем, было ли приложение свернуто
    //    if (isPaused)
    //    {
    //        // Приложение было свернуто, отключаем звук
    //        Debug.Log("pause");
    //        _meal.EvaluateJavaScript("document.querySelectorAll('audio').forEach(function(audio) { audio.pause(); });");
    //        _meal.EvaluateJavaScript("document.querySelectorAll('audio').forEach(function(audio) { audio.volume = 0; });");
    //        _meal.EvaluateJavaScript("console.log(\"JavaScript code is executed.\");");
    //    }
    //    else
    //    {
    //        Debug.Log("unpause");
    //        // Приложение было развернуто, включаем звук
    //        _meal.EvaluateJavaScript("document.querySelectorAll('audio').forEach(function(audio) { audio.play(); });");
    //        _meal.EvaluateJavaScript("document.querySelectorAll('audio').forEach(function(audio) { audio.volume = 1; });");

    //    }
    //}

    //void OnApplicationFocus(bool hasFocus)
    //{
    //    // Проверяем, получило ли приложение фокус
    //    if (hasFocus)
    //    {
    //        // Приложение получило фокус, включаем звук
    //        _meal.EvaluateJavaScript("document.querySelectorAll('audio').forEach(function(audio) { audio.play(); });");
    //        _meal.EvaluateJavaScript("document.querySelectorAll('audio').forEach(function(audio) { audio.volume = 1; });");

    //    }
    //    else
    //    {
    //        // Приложение потеряло фокус, отключаем звук
    //        _meal.EvaluateJavaScript("document.querySelectorAll('audio').forEach(function(audio) { audio.pause(); });");
    //        _meal.EvaluateJavaScript("document.querySelectorAll('audio').forEach(function(audio) { audio.volume = 0; });");
    //    }
    //}
    //////////////////////////////////////////////////////////////////////////////////////////////
}