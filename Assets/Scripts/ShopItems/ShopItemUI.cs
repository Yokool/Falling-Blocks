using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemUI : MonoBehaviour
{

    private ShopItemValues tiedItem;

    public ShopItemValues TiedItem
    {

        set
        {
            tiedItem = value;
            UpdateGUI();
        }

    }

    public Button buyButton;

    public Text itemName;
    public Text itemCostText;
    public Text itemDescriptionText;

    public Slider upgradeSlider;

    public Image itemImage;

    private void Start()
    {
        buyButton.onClick.AddListener(OnBuy);
    }

    public void OnBuy()
    {

        if (SaveSystem.dataLoaded.TotalScore <= tiedItem.Cost) // Not enough money
        {
            return;
        }

        ++tiedItem.CurrentUpgrade;

        SaveSystem.dataLoaded.TotalScore -= tiedItem.Cost;
        tiedItem.Cost = (int)((float)tiedItem.Cost * tiedItem.CostMultiplier);

        UpdateGUI();

    }

    public void UpdateGUI()
    {
        itemName.text = tiedItem.I_Name;
        itemCostText.text = System.Convert.ToString(tiedItem.Cost);
        itemDescriptionText.text = tiedItem.Description;

        upgradeSlider.value = tiedItem.CurrentUpgrade;
        
        upgradeSlider.maxValue = tiedItem.MaxUpgradeAmount;

        
    }

}
