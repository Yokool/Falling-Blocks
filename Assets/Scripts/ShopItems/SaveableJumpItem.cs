using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

[System.Serializable]
public class SaveableJumpItem : SaveableShopItem<Jump>
{

    

    public float jumpHeight;
    public float jumpCooldown;


    public SaveableJumpItem()
    {

    }

    public SaveableJumpItem(string path) : base(path)
    {

    }

    public override void LoadValuesFromFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableJumpItem));
        FileStream stream = LoadAssociatedFile(FileMode.Open);
        SaveableJumpItem thisItem = xmlSerializer.Deserialize(stream) as SaveableJumpItem;
        stream.Close();


        jumpHeight = thisItem.jumpHeight;
        jumpCooldown = thisItem.jumpCooldown;
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
        jumpHeight = GameConstants.jumpHeight_DEFAULT;
        jumpCooldown = GameConstants.jumpCooldown_DEFAULT;
    }

    public override void SaveToFile()
    {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SaveableJumpItem));
        FileStream stream = LoadAssociatedFile(FileMode.Truncate);
        xmlSerializer.Serialize(stream, this);
        stream.Close();
    }
}
