using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class SaveableJetpackItem : SaveableShopItem<Jetpack>
{
    public float jetpackRefuelIncrement;
    

    public float jetpackSpendFuelDecrement;
    

    public float maxFuel;
    

    public float jetpackStrength;
    
    public SaveableJetpackItem()
    {

    }

    public SaveableJetpackItem(string path) : base(path)
    {
        
    }

    public override void LoadValuesFromFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableJetpackItem));
        FileStream stream = LoadAssociatedFile();
        SaveableJetpackItem thisItem = xmlSerializer.Deserialize(stream) as SaveableJetpackItem;
        stream.Close();

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
        jetpackRefuelIncrement = GameConstants.jetpackRefuelIncrement_DEFAULT;
        jetpackSpendFuelDecrement = GameConstants.jetpackSpendFuelDecrement_DEFAULT;
        maxFuel = GameConstants.maxFuel_DEFAULT;
        jetpackStrength = GameConstants.jetpackStrength_DEFAULT;
    }

    public override void SaveToFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableJetpackItem));
        FileStream stream = LoadAssociatedFile();
        xmlSerializer.Serialize(stream, this);
        stream.Close();
    }
}
