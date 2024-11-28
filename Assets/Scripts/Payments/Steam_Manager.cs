#if UNITY_STANDALONE
using UnityEngine;
using Steamworks;

public class Steam_Manager : MonoBehaviour, IPaymentPlatform
{
    private bool isSteamInitialized;

    private void Awake()
    {
        InitializeSteam();
    }

    private void InitializeSteam()
    {
        isSteamInitialized = SteamAPI.Init();

        if (isSteamInitialized)
        {
            Debug.Log("Steamworks initialized successfully.");
        }
        else
        {
            Debug.LogError("SteamAPI_Init() failed. Ensure Steam is running and App ID is correct.");
        }
    }

    public void BuyDiamonds()
    {
        if (!isSteamInitialized)
        {
            Debug.LogError("Steamworks is not initialized. Cannot process purchase.");
            return;
        }

        Debug.Log("Simulating diamond purchase via Steam...");
        PlayerInventory.AddDiamonds(300);
    }

    private void OnDestroy()
    {
        if (isSteamInitialized)
        {
            SteamAPI.Shutdown();
            Debug.Log("Steamworks API shutdown.");
        }
    }
}
#endif