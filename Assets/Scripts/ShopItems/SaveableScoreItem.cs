using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
[System.Serializable]
public class SaveableScoreItem : SaveableShopItem<Score>
{
    public float scoreMultiplier;
    
    public SaveableScoreItem()
    {

    }
    public SaveableScoreItem(string path) : base(path)
    {

    }

    public override void LoadValuesFromFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableScoreItem));
        FileStream stream = LoadAssociatedFile(FileMode.Open);
        SaveableScoreItem item = xmlSerializer.Deserialize(stream) as SaveableScoreItem;
        stream.Close();
        this.scoreMultiplier = item.scoreMultiplier;
    }

    public override void PopulateScript(Score script)
    {
        script.scoreMultiplier = this.scoreMultiplier;
    }

    public override void SetValues(Score script)
    {
        this.scoreMultiplier = script.scoreMultiplier;
    }

    public override void LoadDefaultValues()
    {
        scoreMultiplier = GameConstants.scoreMultiplier_DEFAULT;
    }

    public override void SaveToFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableScoreItem));
        FileStream stream = LoadAssociatedFile(FileMode.Truncate);
        xmlSerializer.Serialize(stream, this);
        stream.Close();
    }

}
