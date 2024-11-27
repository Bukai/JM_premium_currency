using UnityEngine;

public class Shop_Manager : MonoBehaviour
{
    public void BuyHeroSkin()
    {
        int skinCost = 250;

        if (PlayerInventory.Diamonds >= skinCost)
        {
            PlayerInventory.DeductDiamonds(skinCost);
            Debug.Log("Hero skin purchased successfully!");
        }
        else
        {
            Debug.LogError("Not enough diamonds to purchase the hero skin.");
        }
    }
}
