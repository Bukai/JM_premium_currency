using UnityEngine;

public class Payments_Manager : MonoBehaviour
{
    private IPaymentPlatform paymentPlatform;

    void Start()
    {
        InitializePaymentPlatform();
    }

    private void InitializePaymentPlatform()
    {
#if UNITY_STANDALONE
        GameObject steamManagerObject = new GameObject("SteamManager");
        paymentPlatform = steamManagerObject.AddComponent<Steam_Manager>();
#elif UNITY_ANDROID
        GameObject googlePlayManagerObject = new GameObject("GooglePlayManager");
        paymentPlatform = googlePlayManagerObject.AddComponent<GooglePlay_Manager>();
#elif UNITY_WEBGL
        paymentPlatform = new Web_Manager(); // Web_Manager does not need to inherit MonoBehaviour
#else
        Debug.LogError("Unsupported platform for payments!");
#endif
    }

    public void BuyDiamonds()
    {
        if (paymentPlatform != null)
        {
            paymentPlatform.BuyDiamonds();
        }
        else
        {
            Debug.LogError("No payment system initialized!");
        }
    }
}
