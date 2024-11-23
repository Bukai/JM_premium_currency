using UnityEngine;
using Steamworks;

public class Steam_Manager : IPaymentPlatform
{
    public void BuyDiamonds()
    {
        Debug.Log("Kupowanie diamentów na Steam...");
        // Dodaj tutaj logikê Steamworks dla mikrotransakcji
    }

    public void BuyHeroSkin()
    {
        Debug.Log("Kupowanie skina za diamenty na Steam...");
        // Dodaj logikê odejmowania diamentów i aktywacji skina
    }
}
