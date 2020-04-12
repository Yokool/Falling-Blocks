using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableJetpackItem : SaveableShopItem<Jetpack>
{
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

        jetpackRefuelIncrement = thisItem.jetpackRefuelIncrement;
        jetpackSpendFuelDecrement = thisItem.jetpackSpendFuelDecrement;
        maxFuel = thisItem.maxFuel;
        jetpackStrength = thisItem.jetpackStrength;

    }

    public override void PopulateScript(Jetpack script)
    {
        script.jetpackRefuelIncrement = this.jetpackRefuelIncrement;
        script.jetpackSpendFuelDecrement = this.jetpackSpendFuelDecrement;
        script.maxFuel = this.maxFuel;
        script.jetpackStrength = this.jetpackStrength;
    }

    public override void SetValues(Jetpack script)
    {
        this.jetpackRefuelIncrement = script.jetpackRefuelIncrement;
        this.jetpackSpendFuelDecrement = script.jetpackSpendFuelDecrement;
        this.maxFuel = script.maxFuel;
        this.jetpackStrength = script.jetpackStrength;

    }

    public override void LoadDefaultValues()
    {
        jetpackRefuelIncrement = SaveableDefaultValues.jetpackRefuelIncrement_DEFAULT;
        jetpackSpendFuelDecrement = SaveableDefaultValues.jetpackSpendFuelDecrement_DEFAULT;
        maxFuel = SaveableDefaultValues.maxFuel_DEFAULT;
        jetpackStrength = SaveableDefaultValues.jetpackStrength_DEFAULT;
    }
}
