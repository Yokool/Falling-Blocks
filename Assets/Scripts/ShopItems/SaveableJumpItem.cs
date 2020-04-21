using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class SaveableJumpItem : SaveableShopItem<Jump>
{

    

    public float jumpHeight;

    public SaveableJumpItem()
    {

    }

    public SaveableJumpItem(string path) : base(path)
    {

    }

    public override void LoadValuesFromFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableJumpItem));
        FileStream stream = LoadAssociatedFile();
        SaveableJumpItem thisItem = xmlSerializer.Deserialize(stream) as SaveableJumpItem;
        stream.Close();


        jumpHeight = thisItem.jumpHeight;

    }

    public override void PopulateScript(Jump script)
    {
        script.jumpHeight = this.jumpHeight;
    }

    public override void SetValues(Jump script)
    {
        this.jumpHeight = script.jumpHeight;
    }

    public override void LoadDefaultValues()
    {
        jumpHeight = SaveableDefaultValues.jumpHeight_DEFAULT;
    }

    public override void SaveToFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableJumpItem));
        FileStream stream = LoadAssociatedFile();
        xmlSerializer.Serialize(stream, this);
        stream.Close();
    }
}
