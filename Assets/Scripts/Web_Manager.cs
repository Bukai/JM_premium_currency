using UnityEngine;

public class Web_Manager : MonoBehaviour, IPaymentPlatform
{
    public void BuyDiamonds()
    {
        Debug.Log("Simulating diamond purchase on Web platform...");
        // Web payment logic (e.g., PayPal/Przelewy24) will be added here later
    }

    public void BuyHeroSkin()
    {
        Debug.Log("Simulating hero skin purchase on Web platform...");
        // Add logic for deducting diamonds and activating the skin
    }
}
