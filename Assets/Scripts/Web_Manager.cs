using UnityEngine;

public class Web_Manager : IPaymentPlatform
{
    public void BuyDiamonds()
    {
        Debug.Log("Symulacja zakupu diamentów na platformie Web...");
        // Logika Web bêdzie dodana póŸniej (np. PayPal/Przelewy24)
    }

    public void BuyHeroSkin()
    {
        Debug.Log("Symulacja zakupu skina na platformie Web...");
        // Dodaj logikê Web dla skinów
    }
}
