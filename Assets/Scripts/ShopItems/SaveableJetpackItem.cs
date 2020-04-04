using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableJetpackItem : SaveableShopItem<Jetpack>
{

    private const float jetpackRefuelIncrement_DEFAULT = 0.0025f;
    private const float jetpackSpendFuelDecrement_DEFAULT = 0.05f;
    private const float maxFuel_DEFAULT = 10f;
    private const float jetpackStrength_DEFAULT = 5f;


    public float jetpackRefuelIncrement;
    public float jetpackSpendFuelDecrement;
    public float maxFuel;

    public float jetpackStrength;

    public SaveableJetpackItem(string path) : base(path)
    {
        
    }

    public override void LoadValuesFromFile()
    {

        SaveableJetpackItem thisItem = LoadAssociatedFile() as SaveableJetpackItem;

        if (thisItem == null) // The file was empty.
        {
            jetpackRefuelIncrement = jetpackRefuelIncrement_DEFAULT;
            jetpackSpendFuelDecrement = jetpackSpendFuelDecrement_DEFAULT;
            maxFuel = maxFuel_DEFAULT;
            jetpackStrength = jetpackStrength_DEFAULT;
            return;
        }

        jetpackRefuelIncrement = thisItem.jetpackRefuelIncrement;
        jetpackSpendFuelDecrement = thisItem.jetpackSpendFuelDecrement;
        maxFuel = thisItem.maxFuel;
        jetpackStrength = thisItem.jetpackStrength;

    }

    public override void PopulateScript(ref Jetpack script)
    {
        script.jetpackRefuelIncrement = jetpackRefuelIncrement;
        script.jetpackSpendFuelDecrement = jetpackSpendFuelDecrement;
        script.maxFuel = maxFuel;
        script.jetpackStrength = jetpackStrength;

    }

    public override void SetValues(Jetpack script)
    {

        this.jetpackRefuelIncrement = script.jetpackRefuelIncrement;
        this.jetpackSpendFuelDecrement = script.jetpackSpendFuelDecrement;
        this.maxFuel = script.maxFuel;
        this.jetpackStrength = script.jetpackStrength;

    }


}
