using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopCanvasScript : MonoBehaviour
{

    public static ShopCanvasScript INSTANCE
    {
        get;
        private set;
    }

    public Button exitShopButton;

    void Start()
    {
        exitShopButton.onClick.AddListener(ExitShop);
    }

    public ShopCanvasScript()
    {
        INSTANCE = this;
    }



    public void HideShop()
    {
        gameObject.SetActive(false);
    }

    public void ShowShop()
    {
        gameObject.SetActive(true);
    }

    private void ExitShop()
    {
        HideShop();
        MainMenuCanvasScript.Instance.ShowMainMenu();
    }
}
