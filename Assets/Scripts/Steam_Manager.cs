using UnityEngine;
using Steamworks;

public class Steam_Manager : IPaymentPlatform
{
    public void BuyDiamonds()
    {
        Debug.Log("Kupowanie diament�w na Steam...");
        // Dodaj tutaj logik� Steamworks dla mikrotransakcji
    }

    public void BuyHeroSkin()
    {
        Debug.Log("Kupowanie skina za diamenty na Steam...");
        // Dodaj logik� odejmowania diament�w i aktywacji skina
    }
}
