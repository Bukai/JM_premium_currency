using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField]
    private GameObject imagePanelClose_1;
    [SerializeField]
    private GameObject imagePanelClose_2;
    [SerializeField]
    private GameObject imagePanelOpen_1;
    [SerializeField]
    private GameObject imagePanelOpen_2;
    [SerializeField]
    private GameObject PanelSkins;
    [SerializeField]
    private GameObject PanelDiamonds;

    void Start()
    {
        changePanelToSkin();
    }

    public void changePanelToSkin()
    {
        PanelSkins.SetActive(true);
        PanelDiamonds.SetActive(false);
        imagePanelClose_1.SetActive(false);
        imagePanelClose_2.SetActive(true);
        imagePanelOpen_1.SetActive(true);
        imagePanelOpen_2.SetActive(false);
    }

    public void changePanelToDiamonds()
    {
        PanelDiamonds.SetActive(true);
        PanelSkins.SetActive(false);
        imagePanelClose_1.SetActive(true);
        imagePanelClose_2.SetActive(false);
        imagePanelOpen_1.SetActive(false);
        imagePanelOpen_2.SetActive(true);
    }
}
