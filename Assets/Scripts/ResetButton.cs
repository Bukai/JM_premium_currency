using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetButton : MonoBehaviour
{
    public void ResetShopPreferences()
    {
        PlayerPrefs.DeleteKey("PlayerDiamonds");
        PlayerPrefs.DeleteKey("SkinPurchased");
        PlayerPrefs.DeleteKey("SkinEquipped");

        PlayerPrefs.Save();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
