using UnityEngine;

public static class PlayerInventory
{
    public static int Diamonds { get; private set; } = 0;

    public static void AddDiamonds(int amount)
    {
        Diamonds += amount;
        Debug.Log($"Added {amount} diamonds. Total: {Diamonds}");
    }

    public static void DeductDiamonds(int amount)
    {
        if (Diamonds >= amount)
        {
            Diamonds -= amount;
            Debug.Log($"Deducted {amount} diamonds. Remaining: {Diamonds}");
        }
        else
        {
            Debug.LogError("Not enough diamonds to deduct.");
        }
    }
}
