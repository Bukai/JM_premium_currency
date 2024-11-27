using UnityEngine;

public class Shop_Manager : MonoBehaviour
{
    public int skinCost = 250;

    public void BuyHeroSkin()
    {
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
