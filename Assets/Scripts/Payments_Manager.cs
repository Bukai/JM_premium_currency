using UnityEngine;

public class Payments_Manager : MonoBehaviour
{
    private IPaymentPlatform paymentPlatform;

    void Start()
    {
        InitializePaymentPlatform();
    }

    // Initializes the correct payment platform based on the current platform
    private void InitializePaymentPlatform()
    {
#if UNITY_STANDALONE
        paymentPlatform = new Steam_Manager();
#elif UNITY_ANDROID
        paymentPlatform = new Googleplay_Manager(); // Google Play for Android builds
#elif UNITY_WEBGL
        paymentPlatform = new Web_Manager(); // Web platform (e.g., PayPal)
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

    public void BuyHeroSkin()
    {
        if (paymentPlatform != null)
        {
            paymentPlatform.BuyHeroSkin();
        }
        else
        {
            Debug.LogError("No payment system initialized!");
        }
    }
}
