using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class SaveableLevelItem : SaveableShopItem<TileManager>
{

    public int levelWidth;
    

    public int levelHeight;
    

    public SaveableLevelItem()
    {

    }

    public SaveableLevelItem(string path) : base(path)
    {

    }

    public override void LoadValuesFromFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableLevelItem));
        FileStream stream = LoadAssociatedFile();
        SaveableLevelItem saveableLevelItem = xmlSerializer.Deserialize(stream) as SaveableLevelItem;
        stream.Close();
        
        levelWidth = saveableLevelItem.levelWidth;
        levelHeight = saveableLevelItem.levelHeight;
    }

    public override void PopulateScript(TileManager script)
    {
        script.mapSize = new Vector2(levelWidth, levelHeight);
    }

    public override void SetValues(TileManager script)
    {
        this.levelWidth = (int)script.mapSize.x;
        this.levelHeight = (int)script.mapSize.y;
    }

    public override void LoadDefaultValues()
    {
        levelWidth = GameConstants.levelWidth_DEFAULT;
        levelHeight = GameConstants.levelHeight_DEFAULT;
    }

    public override void SaveToFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableLevelItem));
        FileStream stream = LoadAssociatedFile();
        xmlSerializer.Serialize(stream, this);
        stream.Close();
    }
}
