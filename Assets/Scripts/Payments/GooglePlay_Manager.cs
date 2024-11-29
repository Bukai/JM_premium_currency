using Unity.Services.Core;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.Purchasing.Extension;

public class GooglePlay_Manager : MonoBehaviour, IPaymentPlatform, IDetailedStoreListener
{
    private IStoreController storeController;

    private async void Awake()
    {
        await InitializeUnityGamingServices();
        InitializeIAP();
    }

    private async System.Threading.Tasks.Task InitializeUnityGamingServices()
    {
        try
        {
            await UnityServices.InitializeAsync();
            Debug.Log("Unity Gaming Services initialized successfully.");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Failed to initialize Unity Gaming Services: {e.Message}");
        }
    }

    private void InitializeIAP()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
        builder.AddProduct("diamonds_pack", ProductType.Consumable);
        UnityPurchasing.Initialize(this, builder);
    }

    public void BuyDiamonds()
    {
        if (storeController != null)
        {
            storeController.InitiatePurchase("diamonds_pack");
        }
        else
        {
            Debug.LogError("Google Play IAP is not initialized.");
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        Debug.Log("Google Play IAP initialized.");
    }

    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        Debug.LogError($"IAP initialization failed: {error}. Message: {message}");
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError($"IAP initialization failed: {error}");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (args.purchasedProduct.definition.id == "diamonds_pack")
        {
            Debug.Log("Diamonds purchase completed successfully!");
            PlayerInventory.AddDiamonds(200);
        }
        else
        {
            Debug.LogError($"Unexpected product ID: {args.purchasedProduct.definition.id}");
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.LogError($"Purchase failed for product {product.definition.id}. Reason: {failureDescription.reason}. Message: {failureDescription.message}");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError($"Purchase failed for product {product.definition.id}. Reason: {failureReason}");
    }
}
