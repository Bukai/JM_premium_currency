using UnityEngine;

public class Web_Manager : IPaymentPlatform
{
    public void BuyDiamonds()
    {
        Debug.Log("Symulacja zakupu diament�w na platformie Web...");
        // Logika Web b�dzie dodana p�niej (np. PayPal/Przelewy24)
    }

    public void BuyHeroSkin()
    {
        Debug.Log("Symulacja zakupu skina na platformie Web...");
        // Dodaj logik� Web dla skin�w
    }
}
