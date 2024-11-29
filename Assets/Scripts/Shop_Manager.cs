using UnityEngine;

public class Shop_Manager : MonoBehaviour
{
    private const string SkinPurchasedKey = "SkinPurchased";
    private const string SkinEquippedKey = "SkinEquipped";

    public int skinCost = 250;

    public bool IsSkinPurchased { get; private set; }
    public bool IsSkinEquipped { get; private set; }

    private void Awake()
    {
        LoadSkinState();
    }

    public void BuyHeroSkin()
    {
        if (IsSkinPurchased)
        {
            Debug.Log("Hero skin is already purchased.");
            return;
        }

        if (PlayerInventory.Diamonds >= skinCost)
        {
            PlayerInventory.DeductDiamonds(skinCost);
            IsSkinPurchased = true;
            SaveSkinState();
            Debug.Log("Hero skin purchased successfully!");
        }
        else
        {
            Debug.LogError("Not enough diamonds to purchase the hero skin.");
        }
    }

    public void EquipHeroSkin()
    {
        if (!IsSkinPurchased)
        {
            Debug.LogError("Cannot equip skin. It hasn't been purchased.");
            return;
        }

        IsSkinEquipped = true;
        SaveSkinState();
        Debug.Log("Hero skin equipped.");
    }

    public void UnequipHeroSkin()
    {
        if (!IsSkinEquipped)
        {
            Debug.LogError("Skin is not equipped.");
            return;
        }

        IsSkinEquipped = false;
        SaveSkinState();
        Debug.Log("Hero skin unequipped.");
    }

    private void SaveSkinState()
    {
        PlayerPrefs.SetInt(SkinPurchasedKey, IsSkinPurchased ? 1 : 0);
        PlayerPrefs.SetInt(SkinEquippedKey, IsSkinEquipped ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void LoadSkinState()
    {
        IsSkinPurchased = PlayerPrefs.GetInt(SkinPurchasedKey, 0) == 1;
        IsSkinEquipped = PlayerPrefs.GetInt(SkinEquippedKey, 0) == 1;
    }
}
