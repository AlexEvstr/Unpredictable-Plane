using OneSignalSDK;
using UnityEngine;
using UnityEngine.Android;

public class DataChecker : MonoBehaviour
{
    private void Start()
    {
        ConstrainStuff();
    }

    private void ConstrainStuff()
    {
        Permission.RequestUserPermission("android.permission.POST_NOTIFICATIONS");
        OneSignal.Initialize("bf335d63-b991-4448-b852-3ce28e64a965");
        Branch.initSession(CallbackWithBranchUniversalObject);
    }

    private void CallbackWithBranchUniversalObject(BranchUniversalObject buo, BranchLinkProperties linkProps, string error)
    {
        if (error != null) Debug.LogError($"Error : {error}");
        else if (linkProps.controlParams.Count > 0) Debug.Log("Deeplink params : " + buo.ToJsonString() + linkProps.ToJsonString());
    }
}