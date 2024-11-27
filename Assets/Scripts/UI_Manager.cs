using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject PanelSkins;
    [SerializeField] private GameObject PanelDiamonds;
    [SerializeField] private GameObject[] tabsInactive;
    [SerializeField] private GameObject[] tabsActive;
    [SerializeField] private Payments_Manager paymentsManager;
    [SerializeField] private Shop_Manager shopManager;
    [SerializeField] private TextMeshProUGUI diamondCountText;

    void Start()
    {
        UpdateDiamondCount(PlayerInventory.Diamonds);
        ChangePanel(0);
    }

    public void UpdateDiamondCount(int amount)
    {
        if (diamondCountText != null)
        {
            diamondCountText.text = $"Diamonds: {amount}";
        }
    }

    public void OnBuyDiamondsButton()
    {
        if (paymentsManager != null)
        {
            paymentsManager.BuyDiamonds();
            UpdateDiamondCount(PlayerInventory.Diamonds);
        }
        else
        {
            Debug.LogError("Payments_Manager reference is missing!");
        }
    }

    public void OnBuyHeroSkinButton()
    {
        if (shopManager != null)
        {
            shopManager.BuyHeroSkin();
            UpdateDiamondCount(PlayerInventory.Diamonds);
        }
        else
        {
            Debug.LogError("ShopManager reference is missing!");
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
    }
}
