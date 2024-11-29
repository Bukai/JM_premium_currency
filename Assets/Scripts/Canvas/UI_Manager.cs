using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private Payments_Manager paymentsManager;
    [SerializeField] private Shop_Manager shopManager;

    [SerializeField] private GameObject PanelSkins;
    [SerializeField] private GameObject PanelDiamonds;
    [SerializeField] private GameObject[] tabsInactive;
    [SerializeField] private GameObject[] tabsActive;
    [SerializeField] private GameObject equipSkinIndicator;

    [SerializeField] private Button buySkinButton;
    [SerializeField] private Button equipSkinButton;

    [SerializeField] private TextMeshProUGUI diamondCountText;
    [SerializeField] private TextMeshProUGUI buySkinText;

    void Start()
    {
        UpdateDiamondCount(PlayerInventory.Diamonds);
        UpdateSkinButtonsState();
        UpdateEquipIndicator();
        ChangePanel(0);
    }

    public void UpdateDiamondCount(int amount)
    {
        if (diamondCountText != null)
        {
            diamondCountText.text = $"Diamonds: {amount}";
        }

        UpdateSkinButtonsState();
    }

    public void OnBuyDiamondsButton()
    {
        if (paymentsManager != null)
        {
            paymentsManager.BuyDiamonds();
            UpdateDiamondCount(PlayerInventory.Diamonds);
        }
    }

    public void OnBuyHeroSkinButton()
    {
        if (shopManager != null && !shopManager.IsSkinPurchased)
        {
            shopManager.BuyHeroSkin();
            UpdateDiamondCount(PlayerInventory.Diamonds);
            UpdateSkinButtonsState();
        }
    }

    public void OnEquipHeroSkinButton()
    {
        if (shopManager != null && shopManager.IsSkinPurchased && !shopManager.IsSkinEquipped)
        {
            shopManager.EquipHeroSkin();
            UpdateSkinButtonsState();
            UpdateEquipIndicator();
        }
    }

    private void UpdateSkinButtonsState()
    {
        if (buySkinButton != null)
        {
            int missingDiamonds = shopManager.skinCost - PlayerInventory.Diamonds;

            buySkinButton.gameObject.SetActive(!shopManager.IsSkinPurchased);

            if (PlayerInventory.Diamonds >= shopManager.skinCost)
            {
                buySkinButton.interactable = true;
                buySkinText.text = $"{shopManager.skinCost}";
                buySkinText.color = new Color(0, 1, 0);
            }
            else
            {
                buySkinButton.interactable = false;
                buySkinText.text = $"{missingDiamonds}";
                buySkinText.color = new Color(1, 0, 0);
            }
        }

        if (equipSkinButton != null)
        {
            equipSkinButton.gameObject.SetActive(shopManager.IsSkinPurchased);
            equipSkinButton.interactable = shopManager.IsSkinPurchased && !shopManager.IsSkinEquipped;
        }
    }

    private void UpdateEquipIndicator()
    {
        if (equipSkinIndicator != null)
        {
            equipSkinIndicator.SetActive(shopManager.IsSkinEquipped);
        }
    }

    public void ChangePanel(int activePanelIndex)
    {
        if (tabsInactive == null || tabsActive == null || tabsInactive.Length != tabsActive.Length)
        {
            Debug.LogError("Tabs are not configured properly.");
            return;
        }

        PanelSkins.SetActive(activePanelIndex == 0);
        PanelDiamonds.SetActive(activePanelIndex == 1);

        for (int i = 0; i < tabsInactive.Length; i++)
        {
            tabsInactive[i].SetActive(i != activePanelIndex);
            tabsActive[i].SetActive(i == activePanelIndex);
        }

        UpdateSkinButtonsState();
    }
}
