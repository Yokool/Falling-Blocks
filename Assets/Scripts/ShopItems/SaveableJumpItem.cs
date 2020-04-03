using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveableJumpItem : SaveableShopItem<Jump>
{

    private const float jumpHeight_DEFAULT = 250;

    public float jumpHeight;



    public SaveableJumpItem(string path) : base(path)
    {

    }

    public override void LoadValuesFromFile()
    {
        SaveableJumpItem thisItem = LoadAssociatedFile() as SaveableJumpItem;

        if(thisItem == null)
        {
            jumpHeight = jumpHeight_DEFAULT;
            
            return;
        }

        jumpHeight = thisItem.jumpHeight;

    }

    public override void PopulateScript(ref Jump script)
    {
        this.jumpHeight = script.jumpHeight;
    }

    public override void SetValues(Jump script)
    {
        script.jumpHeight = this.jumpHeight;
    }
}
