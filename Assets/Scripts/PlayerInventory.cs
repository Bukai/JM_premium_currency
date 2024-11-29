using UnityEngine;

public static class PlayerInventory
{
    private const string DiamondsKey = "PlayerDiamonds";

    public static int Diamonds
    {
        get => PlayerPrefs.GetInt(DiamondsKey, 0);
        private set
        {
            PlayerPrefs.SetInt(DiamondsKey, value);
            PlayerPrefs.Save();
        }
    }

    public static void AddDiamonds(int amount)
    {
        if (amount > 0)
        {
            Diamonds += amount;
            Debug.Log($"Added {amount} diamonds. Total: {Diamonds}");
        }
    }

    public static void DeductDiamonds(int amount)
    {
        if (amount > 0 && Diamonds >= amount)
        {
            Diamonds -= amount;
            Debug.Log($"Deducted {amount} diamonds. Total: {Diamonds}");
        }
        else
        {
            Debug.LogError("Not enough diamonds to deduct or invalid amount.");
        }
    }
}
