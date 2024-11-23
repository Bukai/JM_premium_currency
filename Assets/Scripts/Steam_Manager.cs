using UnityEngine;
using Steamworks;

public class Steam_Manager : MonoBehaviour, IPaymentPlatform
{
    public Steam_Manager()
    {
        InitializeSteam();
    }

    // Initialize Steamworks API
    private void InitializeSteam()
    {
        if (SteamAPI.Init())
        {
            Debug.Log("Steamworks initialized successfully.");
        }
        else
        {
            Debug.LogError("Failed to initialize Steamworks.");
        }
    }

    public void BuyDiamonds()
    {
        Debug.Log("Attempting to purchase diamonds via Steam...");

        StartMicrotransaction("diamonds_pack");
    }

    public void BuyHeroSkin()
    {
        Debug.Log("Attempting to purchase a hero skin via Steam...");

        StartMicrotransaction("hero_skin");
    }

    // Handle Steam microtransaction
    private void StartMicrotransaction(string productId)
    {
        uint appId = (uint)SteamUtils.GetAppID().m_AppId;
        string userSteamId = SteamUser.GetSteamID().ToString();

        Debug.Log($"Starting microtransaction for product: {productId} with App ID: {appId}");
    }

    public void ShutdownSteam()
    {
        SteamAPI.Shutdown();
        Debug.Log("Steamworks API shutdown.");
    }
}
