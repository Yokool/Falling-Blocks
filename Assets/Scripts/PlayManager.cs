using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    
    public PlayManager INSTANCE { get; private set; }

    public PlayManager()
    {
        INSTANCE = this;
    }

    public void NewGame()
    {

    }


}
