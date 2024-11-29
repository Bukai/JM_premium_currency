using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }

    [SerializeField] private GameObject popupPrefab;
    [SerializeField] private Canvas targetCanvas;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowPopup()
    {
        if (popupPrefab != null && targetCanvas != null)
        {
            Instantiate(popupPrefab, targetCanvas.transform);
        }
        else
        {
            Debug.LogError("Popup prefab or target canvas is not assigned in PopupManager!");
        }
    }
}
