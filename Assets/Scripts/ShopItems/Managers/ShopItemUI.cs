using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{

    private ItemUpgradeManager itemManager;

    public ItemUpgradeManager ItemManager
    {

        set
        {
            itemManager = value;
            UpdateGUI();
        }

    }

    public Button buyButton;

    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemCostText;
    public TextMeshProUGUI itemDescriptionText;

    public Slider upgradeSlider;

    public Image itemImage;

    private void Start()
    {
        buyButton.onClick.AddListener(OnBuy);
        UpdateGUI();
    }

    public void OnBuy()
    {
        itemManager.BuyItem();  
        UpdateGUI();
    }

    public void UpdateGUI()
    {

        itemName.text = itemManager.I_Name;
        itemCostText.text = System.Convert.ToString(itemManager.Cost);
        itemDescriptionText.text = itemManager.Description;
        if(itemManager.ItemImage != null)
        {
            itemImage.sprite = itemManager.ItemImage;
        }
        

        upgradeSlider.value = itemManager.CurrentUpgrade;
        
        upgradeSlider.maxValue = itemManager.MaxUpgradeAmount;

        
    }

}
