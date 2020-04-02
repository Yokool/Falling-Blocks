using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShopSaveSystem
{

    public static SaveableJetpackItem SerializedJetpack;

    public static SaveableJumpItem SerializedJump;

    public static List<ItemUpgradeManager> upgradeManagers = new List<ItemUpgradeManager>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
    public static void InitializeItemSaveSystem()
    {

        CreateItems();
        CreateItemManagers();

    }

    private static void CreateItems()
    {

        SerializedJetpack = new SaveableJetpackItem("/Jetpack.shopitem");

        SerializedJump = new SaveableJumpItem("/Jump.shopitem");

    }

    private static void CreateItemManagers()
    {

        ItemUpgradeManager itemUpgradeManager = new ItemUpgradeManager("Jetpack", "Jetpack it up", 500, null, 1.1f, 50, new OnJetpackShopBuy());

        upgradeManagers.Add(itemUpgradeManager);

    }


}
