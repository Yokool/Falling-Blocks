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

    

    public void OnBuy()
    {

        if (SaveSystem.dataLoaded.TotalScore <= tiedItem.cost) // Not enough money
        {
            return;
        }

        ++tiedItem.currentUpgrade;

        SaveSystem.dataLoaded.TotalScore -= tiedItem.cost;

        UpdateGUI();

    }

    public void UpdateGUI()
    {
        itemName.text = tiedItem.i_name;
        itemCostText.text = System.Convert.ToString(tiedItem.cost);
        itemDescriptionText.text = tiedItem.description;

        upgradeSlider.value = tiedItem.currentUpgrade;
        upgradeSlider.maxValue = tiedItem.maxUpgradeAmount;

        buyButton.onClick.AddListener(OnBuy);
    }

}
